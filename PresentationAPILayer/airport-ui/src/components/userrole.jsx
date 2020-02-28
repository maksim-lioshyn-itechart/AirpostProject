import React from 'react'

class UserRole extends React.Component {
  componentDidMount() {
    this.intervalCoordinateID = setInterval(
      () => { this.getTest(); },
      5000
    );
  }
  async getTest() {

    const response = await fetch("https://localhost:44366/UserRoles", {
      method: "GET", 
      headers: {"Content-Type": "text/plain;charset=UTF-8"}
    })
      .then(r => r.json());
      
      this.setState({
        userRoles: response
      });

    console.log(this.state.userRoles);
  }

  state = {
    userRoles: []
  }

  render() {
    return <h1>Привет, kalsdkfjkh</h1>;
  }
}

export default UserRole;