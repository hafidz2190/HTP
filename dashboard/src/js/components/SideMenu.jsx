import React from 'react';
import { Menu, Icon } from 'antd';
import { Link } from 'react-router-dom';

export default class SideMenu extends React.Component {
    state = {
        collapsed: false,
    }

    toggleCollapsed = () => {
        this.setState({
            collapsed: !this.state.collapsed,
        });
    }

    render() {
        return (
            <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
                <Menu.Item key="1">
                    <Link to='/'>
                        <Icon type="home" />
                        <span>Dashboard</span>
                    </Link>
                </Menu.Item>
                <Menu.Item key="2">
                    <Link to='/profile'>
                        <Icon type="user" />
                        <span>Profil</span>
                    </Link>
                </Menu.Item>
                <Menu.Item key="3">
                    <Link to='/information'>
                        <Icon type="info-circle" />
                        <span>Hasil Perekaman</span>
                    </Link>
                </Menu.Item>
                <Menu.Item key="4">
                    <Link to='/adjustment'>
                        <Icon type="desktop" />
                        <span>Adjustment</span>
                    </Link>
                </Menu.Item>
                <Menu.Item key="9">
                    <Link to='/generate-payment'>
                        <Icon type="credit-card" />
                        <span>Generate Pembayaran</span>
                    </Link>
                </Menu.Item>
            </Menu>
        );
    }
}