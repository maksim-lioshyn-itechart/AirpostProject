import React, { Component } from 'react';
import Contacts from './components/contacts';
import './App.css';

class App extends Component {

  componentDidMount() {
    this.intervalCoordinateID = setInterval(
      () => { this.getTest(); },
      5000
    );
  }

  async getTest() {

    const response = await fetch("https://localhost:32768/weatherforecast", {
      method: "GET", // POST, PUT, DELETE, etc.
      headers: {
        // значение этого заголовка обычно ставится автоматически,
        // в зависимости от тела запроса
        "Content-Type": "text/plain;charset=UTF-8"
      },
      body: undefined, // string, FormData, Blob, BufferSource или URLSearchParams
      // или URL с текущего источника
      referrerPolicy: "no-referrer-when-downgrade", // no-referrer, origin, same-origin...
      mode: "cors", // same-origin, no-cors
      credentials: "same-origin", // omit, include
      cache: "default", // no-store, reload, no-cache, force-cache или only-if-cached
      redirect: "follow", // manual, error
      integrity: "", // контрольная сумма, например "sha256-abcdef1234567890"
      keepalive: false, // true
      signal: undefined, // AbortController, чтобы прервать запрос
      window: window // null
    })
      .then(r => r.json());

    console.log(response);
  }


  state = {
    contacts: []
  }

  render() {
    return (
      <Contacts contacts={this.state.contacts} />
    )
  }
}

export default App;
