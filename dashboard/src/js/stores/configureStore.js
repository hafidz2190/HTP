import { createStore , applyMiddleware} from 'redux';
import thunk from 'redux-thunk';
import rootReducer from './reducers';
import { logger } from 'redux-logger';

function configureStore() {
  const store = createStore(
    rootReducer,
    applyMiddleware(thunk,logger)
  );

  return store;
}

export default configureStore;