import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface FetchNotesDataState {
    notes: NotesData[];
    loading: boolean;
}

export class FetchData extends React.Component<RouteComponentProps<{}>, FetchNotesDataState>
{
    constructor()
    {
        super();
        this.state = { notes: [], loading: true };

        fetch('api/StorMe/Notes')
            .then(response => response.json() as Promise<NotesData[]>)
            .then(data => {
                this.setState({ notes: data, loading: false });
            });
    }

    public render()
    {
        let contents = this.renderAllNotes(this.state.notes);

        return <div>
            <h1>StorMe</h1>
            <p>
                <Link to="/addNote">Create New</Link>
            </p>
            {contents}
        </div>;  
    }

    // Handle Delete Request  
    private handleDelete(id: number) {
        if (!confirm("Do you want to delete this note? "))
            return;
        else {
            fetch('api/StorMe/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        notes: this.state.notes.filter((rec) => {
                            return (rec.noteId != id);
                        })
                    });
            });
        }
    }

	// Handle Edit Request
    private handleEdit(id: number) {
        this.props.history.push("/StorMe/edit/" + id);
    }  

    public renderAllNotes(notes: NotesData[] )
    {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>NoteId</th>
                    <th>Label</th>
                    <th>Title</th>
                    <th>Text</th>
                </tr>
            </thead>
            <tbody>
                {notes.map(note =>
                    <tr key={note.noteId}>
                        <td></td>
                        <td>{note.noteId}</td>
                        <td>{note.label}</td>
                        <td>{note.title}</td>
                        <td>{note.text}</td>
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(note.noteId)}>Edit</a>  |
                            <a className="action" onClick={(id) => this.handleDelete(note.noteId)}>Delete</a>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;  
    }
}

export class NotesData {
    noteId: number = 0;
    label: string = "";
    title: string = "";
    text: string = "";
}