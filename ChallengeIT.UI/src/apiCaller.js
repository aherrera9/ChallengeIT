import axios from 'axios';
import {SERVER_URL} from './config/env'


export async function getChallengeCategories() {
    return axios.get(`${SERVER_URL}/category`);
}

export async function getUsers() {
    return axios.get(`${SERVER_URL}/player`);
}

export async function getRanking() {
    return axios.get(`${SERVER_URL}ranking`);
}

export async function challengePlayer(currentUserId, challengerId, categoryId) {
    return {id:5};
};

export async function cancelChallenge(challengeId) {
    return {id:5};
};

