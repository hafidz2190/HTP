import React from 'react';
import { Table } from 'antd';

const columns = [{
    title: 'Username',
    dataIndex: 'username',
}, {
    title: 'Email',
    dataIndex: 'email',
}, {
    title: 'Phone',
    dataIndex: 'phone',
},  {
    title: 'Nama Bank',
    dataIndex: 'namaBank',
}];
const data = [{
    key: 'username',
    username: 'User Name',
    email: 'lombok@rocketmail.com',
    phone: '080989999',
    namaBank: 'BNI Syariah'
}];

export default class TransactionTable extends React.Component {
    render() {
        return (
            <Table
                columns={columns}
                dataSource={data}/>
        );
    }
}