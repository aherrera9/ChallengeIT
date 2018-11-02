import axios from 'axios';
import {SERVER_URL} from './config/env'


export async function getChallengeCategories() {
    return axios.get(`${SERVER_URL}/category`);
}

export async function getUsers() {
    return axios.get(`${SERVER_URL}/player`);
}

export async function getRanking(categoryId) {
    return axios.get(`${SERVER_URL}/rank?categoryId=${categoryId}`);
}

export async function getChallengeByUser(userId) {
    return axios.get(`${SERVER_URL}/player/${userId}/challengestatus`);
}

export async function setChallengeResult(challengeId, userSender, result) {
    // let postData = {
    //     challengeId,
    //     userSender,
    //     result
    // }
    // return axios.post(`${SERVER_URL}challenge/${challengeId}/setChallengeResult`, postData);
    return true;
}

export async function challengePlayer(currentUserId, challengerId, categoryId) {
    let postData = {
        categoryId,
        challengerId: currentUserId,
        opponentId: challengerId
    }
    return axios.post(`${SERVER_URL}/challenge/createchallenge`, postData );
};

export async function cancelChallenge(challengeId) {
    return {id:5};
};

