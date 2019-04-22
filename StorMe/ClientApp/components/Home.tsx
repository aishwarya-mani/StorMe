import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>StorMe</h1>
            <p>A simple notes app that lets you manage and organize your thoughts! ;)</p>
        </div>;
    }
}
