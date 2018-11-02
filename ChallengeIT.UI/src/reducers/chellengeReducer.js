import {SET_CURRENT_CHALLENGE, SET_POLL_TIMER} from '../actions/actionTypes';

const initialState = {
  currentChallenge: null
};

export default function searchReducer(state = initialState, action) {
  switch (action.type) {
    case SET_CURRENT_CHALLENGE: {
      return Object.assign({}, state, {currentChallenge: action.challenge});
    }
    case SET_POLL_TIMER: {
      return Object.assign({}, state, {timer: action.timer});
    }
    default: {
      return state;
    }
  }
}