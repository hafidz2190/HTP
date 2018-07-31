import React, { Component } from 'react';
import PropTypes from 'prop-types';
import logo from './logo.svg';
import './App.css';

import * as AppStateAction from './js/stores/actions/appStateActions';

import { HubConnection } from 'signalr-client-react';
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
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>
      </div>
    );
  }
}


export default connect(mapStateToProps, mapDispatchToProps)(App);

App.propTypes = {
    appState: PropTypes.any,
    appStateAction: PropTypes.any
};
