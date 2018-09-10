import React from 'react';
import { Button, Input, Icon, Form } from 'antd';

const FormItem = Form.Item;

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
    handleSubmit = (evt) => {
        evt.preventDefault();
        this.props.onLogin(this.state.userName);
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
            background: '#f9f9f9',
            width: '100%',
            height: '100%',
            zIndex: 3,
        }
        return (
            <div style={pageContainerStyle}>
                <Form style={{ margin: '30vh auto 0', maxWidth: '300px' }} onSubmit={this.handleSubmit} className="form-login">
                    <h3>BPPKD KOTA SURABAYA</h3>
                    <FormItem>
                        <Input
                            placeholder="Enter your username"
                            prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                            suffix={uSuffix}
                            value={userName}
                            onChange={this.onChangeUserName}
                            ref={node => this.userNameInput = node}
                        />
                    </FormItem>
                    <FormItem>
                        <Input
                            type="password"
                            placeholder="Enter your password"
                            prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />}
                            suffix={pSuffix}
                            value={password}
                            onChange={this.onChangePassword}
                            ref={node => this.passwordInput = node}
                        />
                    </FormItem>
                    <Button style={{ width: '100%' }} htmlType="submit" className="login-form-button" type="primary"> Login </Button>
                </Form>
            </div>
        )
    }
}