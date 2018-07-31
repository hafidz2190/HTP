import * as ActionType from '../../constants/actionType';
import { VIEW_MODE } from '../../constants/dataEnum';

const initialState = {
    host: 'http://localhost:5005',
    login: {
        username: '',
        userID: '',
        sessionID: ''
    },
    viewMode: VIEW_MODE.NORMAL
};

export default function appStateReducer(state = initialState, action) {
    switch (action.type) {
        case ActionType.SET_LOGIN_INFO:
            return Object.assign({}, state, { login: action.login });
        case ActionType.CHANGE_VIEW:
            return Object.assign({}, state, { viewMode: action.view });
        default:
            return state;
    }
}