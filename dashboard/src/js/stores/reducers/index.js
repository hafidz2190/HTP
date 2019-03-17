import { combineReducers } from 'redux';
import appState from './appState';
import userState from './userState';

const rootReducer = combineReducers({
  appState,
  userState,
});

export default rootReducer;