import {SET_CURRENT_USER, SET_CHALLENGED_USER} from './actionTypes';

export function setCurrentUser(user) {
  return {type: SET_CURRENT_USER, user};
}

export function setChallengedUser(user) {
  return {type: SET_CHALLENGED_USER, user};
}
