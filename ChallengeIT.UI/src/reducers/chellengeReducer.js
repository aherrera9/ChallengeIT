import {SET_CURRENT_CHALLENGE} from '../actions/actionTypes';

const initialState = {
  currentChallenge: null
};

export default function searchReducer(state = initialState, action) {
  switch (action.type) {
    case SET_CURRENT_CHALLENGE: {
      return Object.assign({}, state, {currentChallenge: action.challenge});
    }
    default: {
      return state;
    }
  }
}