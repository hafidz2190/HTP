import React from 'react';
import { Menu, Icon } from 'antd';
import { Link } from 'react-router-dom';

const SubMenu = Menu.SubMenu;

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
                        <Icon type="pie-chart" />
                        <span>Dashboard</span>
                    </Link>
                </Menu.Item>
                <Menu.Item key="2">
                    <Link to='/profile'>
                        <Icon type="desktop" />
                        <span>Profil</span>
                    </Link>
                </Menu.Item>
                <SubMenu
                    key="sub1"
                    title={<span><Icon type="user" /><span>Hasil Perekaman</span></span>}
                >
                    <Menu.Item key="3">Tom</Menu.Item>
                    <Menu.Item key="4">Bill</Menu.Item>
                    <Menu.Item key="5">Alex</Menu.Item>
                </SubMenu>
                <SubMenu
                    key="sub2"
                    title={<span><Icon type="team" /><span>Adjustmen</span></span>}
                >
                    <Menu.Item key="6">Team 1</Menu.Item>
                    <Menu.Item key="8">Team 2</Menu.Item>
                </SubMenu>
                <Menu.Item key="9">
                    <Icon type="file" />
                    <span>Generate Pembayaran</span>
                </Menu.Item>
            </Menu>
        );
    }
}