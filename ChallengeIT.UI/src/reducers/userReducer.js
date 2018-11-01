import {SET_CURRENT_USER, SET_CHALLENGED_USER} from '../actions/actionTypes';

const initialState = {
  currentUser: null,
  challengedUser: null
};

export default function searchReducer(state = initialState, action) {
  switch (action.type) {
    case SET_CURRENT_USER: {
      return Object.assign({}, state, {currentUser: action.user});
    }
    case SET_CHALLENGED_USER: {
      return Object.assign({}, state, {challengedUser: action.user});
    }
    default: {
      return state;
    }
  }
}