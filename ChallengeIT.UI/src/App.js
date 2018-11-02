import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import './App.css';
import Categories from './components/containers/categories';
import Challenges from './components/containers/challenges';
import login from './components/containers/login';
import WaitScreen from './components/containers/waitScreen';
import Ranking from './components/containers/ranking';
import PlayingScreen from './components/containers/playing';

class App extends Component {
  render() {
    return (
      <Router>
        <div className="App">
          <header>
            <span className="appName">
            ChallengeIT!
            </span>            
          </header>
          <div className="content">
            <Route exact path="/" component={login} />
            <Route exact path="/categories" component={Categories} />
            <Route path="/challenges" component={Challenges} />
            <Route path="/wait" component={WaitScreen} />
            <Route path="/playing" component={PlayingScreen} />
            <Route path="/ranking" component={Ranking} />
          </div>
        </div>
      </Router>
    );
  }
}

export default App;
