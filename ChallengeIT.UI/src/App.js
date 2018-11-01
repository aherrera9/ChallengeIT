import React, { Component } from 'react';
import logo from './logo.svg';
import { BrowserRouter as Router, Route, Link } from 'react-router-dom';
import './App.css';
import Home from './components/containers/home';
import Challenge from './components/containers/challenge';

class App extends Component {
  render() {
    return (
      <Router>
        <div className="App">
          <header>
            <p className="appName">
            ChallengeIT!
            </p>            
          </header>
          <div className="content">
            <Route path="/challenges/:categoryId" component={Challenge} />
            <Route exact path="/" component={Home} />
          </div>
        </div>
      </Router>
    );
  }
}

export default App;
