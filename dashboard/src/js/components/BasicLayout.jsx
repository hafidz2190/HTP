import React from 'react';
import { Layout, Breadcrumb } from 'antd';
import SideMenu from './SideMenu';

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
    return (
      <Layout style={{ minHeight: '100vh' }}>
        <Sider
          collapsible
          collapsed={this.state.collapsed}
          onCollapse={this.onCollapse}
        >
          <div className="logo" />
          <SideMenu />
        </Sider>
        <Layout>
          <Header style={{ background: '#fff', padding: 0 }} />
          <Content style={{ margin: '0 16px' }}>
            <Breadcrumb style={{ margin: '16px 0' }}>
              <Breadcrumb.Item>User</Breadcrumb.Item>
              <Breadcrumb.Item>Hendi</Breadcrumb.Item>
            </Breadcrumb>
            <div style={{ padding: 24, background: '#fff', minHeight: 360 }}>
              Dummy content
            </div>
          </Content>
          <Footer style={{ textAlign: 'center' }}>
            HTP Design ©2018 Created by HTP Developer
          </Footer>
        </Layout>
      </Layout>
    );
  }
}