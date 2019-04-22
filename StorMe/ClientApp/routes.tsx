import * as React from 'react';
import { Route } from 'react-router-dom';

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { AddNote } from './components/AddNote';
import { Search } from './components/Search';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/addNote' component={ AddNote } />
    <Route path='/fetchdata' component={ FetchData } />
    <Route path='/StorMe/edit/:noteId' component={ AddNote } />
    <Route path='/search' component={Search} />
</Layout>;