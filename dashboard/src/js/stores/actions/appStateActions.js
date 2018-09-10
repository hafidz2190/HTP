import * as actionType from './../../constants/actionType';

export function login(username) {
    return ({
        type: actionType.SET_LOGIN_INFO, 
        login: {
            username: username,
            userID: 1,
            sessionID: '12122' } 
        });
}
export function logout() {
    return ({
        type: actionType.SET_LOGIN_INFO, 
        login: {
            username: '',
            userID: '',
            sessionID: '' } 
        });
}