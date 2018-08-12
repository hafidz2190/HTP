import React, { Component } from 'react';
import PropTypes from 'prop-types';
import BasicLayout from './js/components/BasicLayout';
// import logo from './logo.svg';
import './App.css';
import 'antd/dist/antd.css';

import * as AppStateAction from './js/stores/actions/appStateActions';

// import { HubConnection } from 'signalr-client-react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

function mapStateToProps(state) {
  return {
    appState: state.appState
  };
}

function mapDispatchToProps(dispatch) {
  return {
    appStateAction: bindActionCreators(AppStateAction, dispatch)
  };
}


class App extends Component {

  render() {
    return (
      <div className="App">
        <BasicLayout />
      </div>
    );
  }
}


export default connect(mapStateToProps, mapDispatchToProps)(App);

App.propTypes = {
    appState: PropTypes.any,
    appStateAction: PropTypes.any
};
