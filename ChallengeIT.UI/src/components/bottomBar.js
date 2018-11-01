import React, { Component } from 'react';


class BottomBar extends Component {
  render() {
    return (
      <div className="bottomBar">
        {this.props.children}
      </div>
    );
  }

  challengePlayer() {}
}

export default BottomBar;
