const _apiUrl = "/api/saving";

export const getSavings = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

//this doesn't work yet
export const addSaving = (saving) => {
    return fetch(`${_apiUrl}/savings`, {
        method: "POST",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(saving)
    })
}