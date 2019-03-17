import * as ActionType from '../../constants/actionType';

const initialState = {
    users: [],
    isFetchingUsers: false,
    successFetchingUsers: true,
    failedFetchingUsers: false,
    errorMessage: ""
};

export default function userStateReducer(state = initialState, action) {
    switch (action.type) {
        case ActionType.FETCH_USERS_REQUEST:
            return {
                ...state,
                isFetchingUsers: true
            }
        case ActionType.FETCH_USERS_FAILED:
            return {
                ...state,
                errorMessage: action.errorMessage,
                isFetchingUsers: false,
                successFetchingUsers: false,
                failedFetchingUser: true,
            }
        case ActionType.FETCH_USERS_SUCCESS:
            return {
                ...state,
                users: action.users,
                isFetchingUsers: false,
                successFetchingUsers: true,
                failedFetchingUser: false
            }
        default: return state;
    }
}