import React from 'react';
import { Table } from 'antd';

const columns = [{
    title: 'Jatuh Tempo',
    dataIndex: 'jatuhTempo',
}, {
    title: '2017',
    dataIndex: '2017',
}, {
    title: '2018',
    dataIndex: '2018',
}];
const data = [{
    key: 'januari',
    jatuhTempo: 'Januari',
    2017: '09 Feb 2017',
    2018: '09 Feb 2018',
}, {
    key: 'februari',
    jatuhTempo: 'Februari',
    2017: '09 Maret 2017',
    2018: '09 Maret 2018',
}, 
{
    key: 'maret',
    jatuhTempo: 'Maret',
    2017: '09 April 2017',
    2018: '09 April 2018',
}, 
{
    key: 'april',
    jatuhTempo: 'April',
    2017: '09 Mei 2017',
    2018: '09 Mei 2018',
}, 
{
    key: 'mei',
    jatuhTempo: 'Mei',
    2017: '09 Juni 2017',
    2018: '09 Juni 2018',
}, 
{
    key: 'juni',
    jatuhTempo: 'Juni',
    2017: '09 Juli 2017',
    2018: '09 Juli 2018',
}, {
    key: 'juli',
    jatuhTempo: 'Juli',
    2017: '09 Agustus 2017',
    2018: '09 Agustus 2018',
}, {
    key: 'agustus',
    jatuhTempo: 'Agustus',
    2017: '09 September 2017',
    2018: '09 September 2018',
}, {
    key: 'september',
    jatuhTempo: 'September',
    2017: '09 Oktober 2017',
    2018: '09 Oktober 2018',
}, {
    key: 'oktober',
    jatuhTempo: 'Oktober',
    2017: '09 November 2017',
    2018: '09 November 2018',
}, {
    key: 'november',
    jatuhTempo: 'November',
    2017: '09 Desember 2017',
    2018: '09 Desember 2018',
}, {
    key: 'desember',
    jatuhTempo: 'Desember',
    2017: '09 Jan 2018',
    2018: '09 Jan 2019',
}];

export default class TransactionTable extends React.Component {
    render() {
        return (
            <Table
                columns={columns}
                dataSource={data} />
        );
    }
}