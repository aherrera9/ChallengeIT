import axios from 'axios';
import {SERVER_URL} from './config/env'


export async function getChallengeCategories() {
    return axios.get(`${SERVER_URL}/category`);
}

export async function getUsers() {
    return axios.get(`${SERVER_URL}/player`);
}

export async function getRanking(category) {
    return { data: [
        {
            rank:1,
            name: 'Mac',
            wins: 38,
            losses: 5
        },
        {
            rank:2,
            name: 'Rocco',
            wins: 25,
            losses: 9
        },
        {
            rank:3,
            name: 'Imtiaz',
            wins: 24,
            losses: 8
        },
        {
            rank:4,
            name: 'Julia',
            wins: 24,
            losses: 4
        },
        {
            rank:5,
            name: 'Jemma',
            wins: 24,
            losses: 3
        },
        {
            rank:6,
            name: 'Fernando',
            wins: 18,
            losses: 8
        },
        {
            rank:7,
            name: 'Gener',
            wins: 15,
            losses: 5
        },
        {
            rank:8,
            name: 'Li',
            wins: 14,
            losses: 5
        },
        {
            rank:9,
            name: 'Mel',
            wins: 13,
            losses: 2
        },
        {
            rank:10,
            name: 'Fred',
            wins: 10,
            losses: 10
        }
    ]};
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

