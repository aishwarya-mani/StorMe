import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { NotesData } from './FetchData';

interface AddNoteDataState {
    title: string;
    loading: boolean;
    allNotes: Array<any>;
    notesData: NotesData;
}

export class AddNote extends React.Component<RouteComponentProps<{}>, AddNoteDataState> {
    constructor(props) {
        super(props);
        this.state = { title: "", loading: true, allNotes: [], notesData: new NotesData };
        fetch('api/StorMe')
            .then(response => response.json() as Promise<Array<any>>)
            .then(data => {
                this.setState({ allNotes: data });
            });

        var id = this.props.match.params["noteId"];

        // This will set state for Edit note  
		if (id > 0) {
            fetch('api/StorMe/Note/' + id)
                .then(response => response.json() as Promise<NotesData>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, notesData: data });
                });
        }

        // This will set state for Add note  
		else {
            this.state = { title: "Create", loading: false, allNotes: [], notesData: new NotesData };
        }

        // This binding is necessary to make "this" work in the callback  

        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    public render() {

        let contents = this.state.loading
            ? <p><em>Loading...!</em></p>
            : this.renderCreateForm(this.state.allNotes);
        return <div>

            <h1>{this.state.title}</h1>
            <h3>Note</h3>
            <hr />
            {contents}
        </div>;
    }

    // This will handle the submit form event.  

    private handleSave(event) {

        event.preventDefault();
        const data = new FormData(event.target);
        
		// PUT request for Edit note.

        if (this.state.notesData.noteId) {
            fetch('api/StorMe/Edit', {
                method: 'PUT',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetchdata");
                })
        }
		
        // POST request for Add note.

        fetch('api/StorMe/Create', {
            method: 'POST',
            body: data,
        }).then((response) => response.json())
            .then((responseJson) => {
                this.props.history.push("/fetchdata");
            })
       
        this.props.history.push("/fetchdata");

    }

    // This will handle Cancel button click event.  

    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchdata");
    }

    // Returns the HTML Form to the render() method.  

    private renderCreateForm(allNotes: Array<any>) {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="noteId" value={this.state.notesData.noteId} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Label">Label</label>
                    <div className="col-md-4">
                         <input className="form-control" type="text" name="label" defaultValue={this.state.notesData.label} required />
                    </div>
                </div >
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Title">Title</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="title" defaultValue={this.state.notesData.title} required />
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Text" >Text</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="text" defaultValue={this.state.notesData.text} required />
                    </div>
                </div>
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div >
            </form >
        )
    }
}