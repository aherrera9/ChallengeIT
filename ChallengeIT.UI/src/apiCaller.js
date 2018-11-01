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
};