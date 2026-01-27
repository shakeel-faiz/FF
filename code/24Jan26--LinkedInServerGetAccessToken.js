const express = require('express');
const axios = require('axios');
const app = express();

// --- CONFIGURATION ---
//const CLIENT_ID = 'YOUR_CLIENT_ID';
//const CLIENT_SECRET = 'YOUR_CLIENT_SECRET';
const CLIENT_ID = '77a1wn140fyyll';
const CLIENT_SECRET = 'WPL_AP1.17ja1Tflw2N6KrzN.AUGf/g==';
const REDIRECT_URI = 'http://localhost:3000/callback';
// Make sure to add w_organization_social once you have the product approved!
const SCOPES = 'w_member_social,openid,profile,email'; 

//https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=77a1wn140fyyll&redirect_uri=http://localhost:3000/callback&scope=w_member_social

// 1. Route to start the process
app.get('/login', (req, res) => {
    const authUrl = `https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=${CLIENT_ID}&redirect_uri=${REDIRECT_URI}&scope=${SCOPES}`;
	
	//console.log(authUrl)
    res.redirect(authUrl);
});

// 2. The Callback route that LinkedIn hits automatically
app.get('/callback', async (req, res) => {
    const code = req.query.code;

    if (!code) return res.send("No code found!");

    try {
        // Exchange Code for Token
        const response = await axios.post('https://www.linkedin.com/oauth/v2/accessToken', null, {
            params: {
                grant_type: 'authorization_code',
                code: code,
                client_id: CLIENT_ID,
                client_secret: CLIENT_SECRET,
                redirect_uri: REDIRECT_URI
            },
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        });

        const token = response.data.access_token;
        console.log("SUCCESS! Your Access Token is:", token);
        res.send(`Token Received! Check your terminal. Token expires in: ${response.data.expires_in} seconds.`);
    } catch (error) {
        console.error("Error exchanging token:", error.response.data);
        res.status(500).send("Auth Failed");
    }
});

app.listen(3000, () => console.log('Visit http://localhost:3000/login to generate your token!'));
