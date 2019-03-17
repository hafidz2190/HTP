import React, { Component } from "react";
import { Select, Button } from 'antd';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import Wrapper from '../common/Wrapper'
import TransactionChart from './TransactionChart';
import TransactionTable from './TransactionTable';
import { fetchUser } from '../../stores/actions/userStateAction'

const Option = Select.Option;

class DashboardPage extends Component {
    componentDidMount() {
        const { users, fetchUser } = this.props;
        if (!users || users.length == 0) {
            fetchUser();
        }
    }
    handleChange(value) {
        console.log(`selected ${value}`);
    }

    handleBlur() {
        console.log('blur');
    }

    handleFocus() {
        console.log('focus');
    }
    render() {
        const { errorMessage, isFetchingUser } = this.props
        return (
            <Wrapper errorMessage={errorMessage} isFetching={isFetchingUser}>
                <div align='left'>
                    <div className={'title'}>
                        <h1>Dashboard</h1><h4>>> overview &amp; stats</h4>
                    </div>
                    <div className={'section'}>
                        <h3>Transaksi User</h3>
                    </div>
                    <div className={'section'}>
                        NOP
                    <Select
                            showSearch
                            style={{ width: 450, marginLeft: 10 }}
                            placeholder="Select a person"
                            optionFilterProp="children"
                            onChange={this.handleChange}
                            onFocus={this.handleFocus}
                            onBlur={this.handleBlur}
                            filterOption={(input, option) => option.props.children.toLowerCase().indexOf(input.toLowerCase()) >= 0}
                        >
                            <Option value="357801100990100007">357801100990100007 - TEST HOTEL AJA - JL. TESTING</Option>
                            <Option value="357801100990100327">357801100990100327 - Kalifornia Fried Egg - JL. DEBUGGING</Option>
                            <Option value="357801100990100997">357801100990100997 - SATE Intermediate - JL. DEVELOP</Option>
                        </Select>
                        <Button icon="search">Search</Button>
                        <Button type="primary" style={{ marginLeft: 10 }}>Tampilkan Tahun Sebelumnya</Button>
                    </div>
                    <div className={'section'}>
                        <h2 style={{ textAlign: 'center' }}>2018</h2>
                        <TransactionChart />
                    </div>
                    <div className={'section'}>
                        <TransactionTable />
                    </div>
                </div>
            </Wrapper>
        )
    }
}

const mapStateToProps = ({ userState }) => {
    return {
        users: userState.users,
        isFetchingUser: userState.isFetchingUsers,
        errorMessage: userState.errorMessage,
    }
}
const mapDispatchToProps = (dispatch) => ({
    fetchUser: bindActionCreators(fetchUser, dispatch),
})

export default connect(mapStateToProps, mapDispatchToProps)(DashboardPage);