import React from 'react';
import { Table } from 'antd';

const columns = [{
    title: 'Tanggal',
    dataIndex: 'tanggal',
    sorter: (a, b) => a.tanggal.length - b.tanggal.length
}, {
    title: 'Pajak Terutang',
    dataIndex: 'pajakTerutang',
    sorter: (a, b) => a.pajakTerutang.length - b.pajakTerutang.length
}, {
    title: 'Keterangan',
    dataIndex: 'keterangan',
    sorter: (a, b) => a.keterangan.length - b.keterangan.length
},  {
    title: 'Tanggal Dibuat',
    dataIndex: 'tanggalDibuat',
    sorter: (a, b) => a.tanggalDibuat.length - b.tanggalDibuat.length
},  {
    title: 'IP Sender',
    dataIndex: 'ipSender',
    sorter: (a, b) => a.ipSender.length - b.ipSender.length
}];
const data = [];

export default class TransactionTable extends React.Component {
    render() {
        return (
            <Table
                title={() => 'Transaction List'}
                columns={columns}
                dataSource={data}/>
        );
    }
}