import React from 'react';
import { Layout, Breadcrumb, Icon } from 'antd';
import { Route } from "react-router-dom";

import SideMenu from '../SideMenu';
import DashboardHeader from '../DashboardHeader';
import DashboardPage from '../DashboardPage';
import ProfilePage from '../ProfilePage';
import InformationPage from '../InformationPage';
import AdjustmentPage from '../AdjustmentPage';
import GeneratePaymentPage from '../GeneratePaymentPage';

import './index.css';

const { Header, Content, Footer, Sider } = Layout;

export default class BasicLayout extends React.Component {
  state = {
    collapsed: false,
  };

  onCollapse = (collapsed) => {
    console.log(collapsed);
    this.setState({ collapsed });
  }

  render() {
    console.log(this.props);
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
              <Route exact path="/" component={DashboardPage} />
              <Route exact path="/profile" component={ProfilePage} />
              <Route exact path="/information" component={InformationPage} />
              <Route exact path="/adjustment" component={AdjustmentPage} />
              <Route exact path="/generate-payment" component={GeneratePaymentPage} />
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