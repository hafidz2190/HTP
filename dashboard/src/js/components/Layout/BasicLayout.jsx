import React from 'react';
import { Layout, Breadcrumb, Icon } from 'antd';
import { Route } from "react-router-dom";

import SideMenu from '../SideMenu';
import LoginPage from '../LoginPage';
import DashboardHeader from '../DashboardHeader';
import { Routes } from '../../constants/routes';

import './index.css';

const { Header, Content, Footer, Sider } = Layout;

export default class BasicLayout extends React.Component {
  state = {
    collapsed: false,
    redirectToReferrer: false
  };

  LoginPageWithProps = () => {
    return (
      <LoginPage
        onLogin={this.props.appStateAction.login}
        {...this.props}
      />
    )
  }

  onCollapse = (collapsed) => {
    this.setState({ collapsed });
  }

  render() {
    return (
      <Layout style={{ minHeight: '100vh' }}>
        <Header style={{
          background: '#fff',
          padding: 0,
          boxShadow: '1px 2px 5px #bedfff5c',
          zIndex: 3,
          position: 'fixed',
          width: '100%'
        }}>
          <DashboardHeader />
        </Header>
        <Layout>
          <Sider
            collapsible
            collapsed={this.state.collapsed}
            onCollapse={this.onCollapse}
            style={{ textAlign: 'left' }}
          >
            <div className="logo" />
            <SideMenu />
          </Sider>
          <Content style={{ margin: '0 0px', position: 'relative', top: 65 }}>
            <Breadcrumb style={{ margin: '16px 0' }}>
              <Breadcrumb.Item>
                <Icon type="home" style={{ marginRight: '5px' }} />
                Home
              </Breadcrumb.Item>
              <Breadcrumb.Item>Dashboard</Breadcrumb.Item>
            </Breadcrumb>
            <div style={{ padding: 24, background: '#fff', minHeight: 360 }}>
              <Route exact path="/login" component={this.LoginPageWithProps} />
              {
                Routes.map((route, id) => {
                  return <Route exact {...route} key={`route${id}`}/>
                })
              }
            </div>
          </Content>
        </Layout>
        <Footer style={{ textAlign: 'center' }}>
          BPPKD PO ©2018
        </Footer>
      </Layout>
    );
  }
}