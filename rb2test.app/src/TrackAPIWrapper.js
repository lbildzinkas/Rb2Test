const api = "http://localhost:55556/api/"
const corsProxy = "https://cors-anywhere.herokuapp.com/";

const headers = {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'Origin' : 'http://localhost:3000',
    'Access-Control-Allow-Origin' : 'http://localhost:3000',
    'Set-Cookie' : 'kek=7fukucsuji1n1ddcntc0ri4vi; Version=1; Path=/; Max-Age=100000'
  }

  export const post = (tracks) =>
        fetch(`${api}meeting/track/`, {
            method: 'POST',
            headers: {
            ...headers
            },
            body: JSON.stringify(tracks)
        }).then(res => res.json())