const api = "http://localhost:55556/api/"

const headers = {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  }

  export const post = (tracks) =>
        fetch(`${api}meeting/track/`, {
            method: 'POST',
            headers: {
            ...headers
            },
            body: JSON.stringify(tracks)
        }).then(res => res.json())