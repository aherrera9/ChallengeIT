import {SET_CURRENT_CHALLENGE, SET_POLL_TIMER} from './actionTypes';

export function setCurrentChallenge(challenge) {
  return {type: SET_CURRENT_CHALLENGE, challenge};
}
export function setPollTimer(timer) {
  return {type: SET_POLL_TIMER, timer};
}
