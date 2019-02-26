import React from 'react';
import { Table } from 'antd';

const columns = [{
    title: 'NOP',
    dataIndex: 'nop',
    sorter: (a, b) => a.nop.length - b.nop.length
}, {
    title: 'Masa Pajak',
    dataIndex: 'masaPajak',
    sorter: (a, b) => a.masaPajak.length - b.masaPajak.length
}, {
    title: 'Tahun',
    dataIndex: 'tahun',
    sorter: (a, b) => a.tahun.length - b.tahun.length
}, {
    title: 'Pajak Terhutang',
    dataIndex: 'pajakTerhutang',
    sorter: (a, b) => a.pajakTerhutang.length - b.pajakTerhutang.length
}];
const data = [];

export default class TransactionTable extends React.Component {
    state = {
        selectedRowKeys: [] // Check here to configure the default column
    }
    onSelectChange = (selectedRowKeys) => {
        console.log('selectedRowKeys changed: ', selectedRowKeys);
        this.setState({ selectedRowKeys });
    }
    render() {
        const { selectedRowKeys } = this.state;
        const rowSelection = {
            selectedRowKeys,
            onChange: this.onSelectChange,
        };
        return (
            <Table
                title={() => 'Generate Payment List'}
                rowSelection={rowSelection}
                columns={columns}
                dataSource={data} />
        );
    }
}