import apiClient from '../../helpers/apiClient'
import {
    FETCH_USERS_REQUEST,
    FETCH_USERS_SUCCESS,
    FETCH_USERS_FAILED 
} from '../../constants/actionType'

export const fetchUser = () => (dispatch, getState) => {
    dispatch({ type: FETCH_USERS_REQUEST })
    apiClient.get('/dev/getAllUser')
        .then(resp => {
            console.log(resp)
            return dispatch({
                type: FETCH_USERS_SUCCESS,
                users: resp.data && resp.data.body !== '' ? resp.data.body : []
            })
        })
        .then(data => {
            console.log(data)
        })
        .catch(error => {
            return dispatch({
                type: FETCH_USERS_FAILED,
                errorMessage: error.toString()
            })
        })
}