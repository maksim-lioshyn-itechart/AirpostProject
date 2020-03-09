import React from 'react';
import UserRole from "./components/UserRole/index";
import Country from './components/Country/index';

class App extends React.Component {
  render() {
    return (
      <div>
        UserRole
        <UserRole/>
        Country
        <Country/>
      </div>
    );
  }
}

export default App;