export async function getChallengeCategories() {
    return {
        data: [
            {
                id: 1,
                name: 'Daytona'
            },
            {
                id: 2,
                name: 'Ping Pong'
            },
            {
                id: 1,
                name: 'Pool'
            },
            {
                id: 2,
                name: 'Ping Pong'
            },
            {
                id: 1,
                name: 'Pool'
            },
            {
                id: 2,
                name: 'Ping Pong'
            },
            {
                id: 1,
                name: 'Pool'
            }
        ]
    }
}

export async function getUsers() {
    return {
        data: [
            {
                id: 1,
                name: 'Antonio'
            },
            {
                id: 2,
                name: 'Rocco'
            },
            {
                id: 3,
                name: 'Imtiaz'
            },
            {
                id: 2,
                name: 'Rocco'
            },
            {
                id: 3,
                name: 'Imtiaz'
            },
            {
                id: 2,
                name: 'Rocco'
            },
            {
                id: 3,
                name: 'Imtiaz'
            }
        ]
    }
}

export async function challengePlayer(currentUserId, challengerId, categoryId) {
    return {id:5};
};

export async function cancelChallenge(challengeId) {
    return {id:5};
};