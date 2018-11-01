import {SET_CURRENT_CHALLENGE} from './actionTypes';

export function setCurrentChallenge(challenge) {
  return {type: SET_CURRENT_CHALLENGE, challenge};
}
