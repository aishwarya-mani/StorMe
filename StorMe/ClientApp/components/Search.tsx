import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Search extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
        this.state = { currentCount: 0 };
    }

    public render() {
        return <div>
            <h1>search</h1>
            <p>This is a simple example of a React component.</p>
        </div>;
    }
}
