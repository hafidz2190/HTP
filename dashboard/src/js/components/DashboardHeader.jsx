import React, { Component } from "react";
import { Dropdown, Menu, Button } from 'antd';

export default class DashboardHeader extends Component {
    render() {
        const menuDropdown = (
            <Menu>
                <Menu.Item>
                    Settings
                </Menu.Item>
                <Menu.Item>
                    Profile
                </Menu.Item>
                <Menu.Item>
                    Change Password
                </Menu.Item>
                <Menu.Divider/>
                <Menu.Item>
                    Logout
                </Menu.Item>
            </Menu>
        );
        return (
            <div align='left'>
                <img
                    style={{ width: '28px', margin: '0 15px' }}
                    src='./assets/img/pemkot-sby.png' alt='logo pemkot' />
                <p
                    style={{ fontSize: '21px', fontWeight: '700', display: 'inline-block' }}>
                    DASHBOARD PAJAK ONLINE
                </p>
                <div style={{float:'right', display: 'inline-block', marginRight: '20px'}}>
                    <Dropdown trigger={['click']} overlay={menuDropdown} placement="bottomRight">
                        <Button>Welcome, User</Button>
                    </Dropdown>
                </div>
            </div>
        )
    }
}
