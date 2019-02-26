import React, { Component } from "react";
import ProfileTable from './ProfileTable';

export default class ProfilePage extends Component {
    render() {
        return (
            <div align='left'>
                <div className={'title'}>
                    <h1>Profile User</h1><h4>>> overview &amp; stats</h4>
                </div>
                <div className={'section'}>
                    <h2>List Profile User</h2>
                    <ProfileTable />
                </div>
            </div>
        )
    }
}
