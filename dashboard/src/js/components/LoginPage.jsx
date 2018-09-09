import React from 'react';
import { Button, Input, Icon } from 'antd';

export default class LoginPage extends React.Component {
    state = {
        userName: '',
        password: ''
    }
    emitEmpty = (type) => {
        if (type == 'username') {
            this.userNameInput.focus();
            this.setState({ userName: '' });
        } else if (type == 'password') {
            this.passwordInput.focus();
            this.setState({ password: '' });
        }
    }
    onChangeUserName = (e) => {
        this.setState({ userName: e.target.value });
    }
    onChangePassword = (e) => {
        this.setState({ password: e.target.value });
    }
    render() {
        const { userName, password } = this.state;
        const uSuffix = userName ? <Icon type="close-circle" onClick={this.emitEmpty.bind(this, 'username')} /> : null;
        const pSuffix = password ? <Icon type="close-circle" onClick={this.emitEmpty.bind(this, 'password')} /> : null;
        const pageContainerStyle = {
            position: 'fixed',
            top: 0,
            left: 0,
            background: 'white',
            width: '100%',
            height: '100%',
            zIndex: 3,
            paddingTop: '50vh',
        }
        return (
            <div style={pageContainerStyle}>
                <div>
                    <h3>Login</h3>
                    <Input
                        placeholder="Enter your username"
                        prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                        suffix={uSuffix}
                        value={userName}
                        onChange={this.onChangeUserName}
                        ref={node => this.userNameInput = node}
                    />
                    <Input
                        type={'password'}
                        placeholder="Enter your password"
                        prefix={<Icon type="key" style={{ color: 'rgba(0,0,0,.25)' }} />}
                        suffix={pSuffix}
                        value={password}
                        onChange={this.onChangePassword}
                        ref={node => this.passwordInput = node}
                    />
                    <Button type={'primary'}> Login </Button>
                </div>
            </div>
        )
    }
}