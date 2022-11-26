# Simple Finite-State Machine

A simple and concise implementation of the state machine.

## Introduction

Hi, this is YooPita! I present to your attention the architecture of the simplest state machine!

- You ask, what's the point of posting such a simple code in a separate repository?
- And I will answer this that it makes sense to give an impetus to understanding how to organize a finite state machine.

## Design

The design idea of this state machine is to hide the state of the object inside it, while moving the logic of the state machine into a separate object using composition.

Here are the features that make this design stand out:
- You cannot reuse states in other objects. The state always belongs to one object.
- The state has full access to the parent object, as if it were the same object, because it is a subclass.
- The state is split into two methods "Execute" and "Calculate next state" just to help you focus on describing the state of your object.

## How to use

Create a main class for which you want to organize states. This class is responsible for moving the character. No movement details, only states and the character's jump.
```c#
// class should be partial
public partial class CharacterMovement
{
  public CharacterMovement()
  {
      InitializeStates();
      _stateMachine = new StateMachine(_states.Falling);
  }
  
  // a property in which we will store the implementations of our states
  private States _states;
  
  // a property common to all states that they can affect
  private bool _canJump = false;
  
  public void Jump()
  {
    if (_canJump) _stateMachine.SetState(_states.Jumping);
  }
  
  private void InitializeStates()
  {
      _states = new States()
      {
          Falling = new Falling(this),
          Grounded = new Grounded(this),
          Jumping = new Jumping(this)
      };
  }
  
  // catalogue of state classes
  private class States
  {
    public IState Falling { get; set; }
    public IState Grounded { get; set; }
    public IState Jumping { get; set; }
  }
}
```

Let's create one of the states of our object:
```c#
public partial class CharacterMovement
{
  private class Jumping : IState
  {
    public Jumping(CharacterMovement characterMovement)
    {
      _characterMovement = characterMovement;
    }

    // local variables that belong only to the state
    private CharacterMovement _characterMovement;
    private float _jumpTime = 5f;
    private float _jumpTimeStep = 0.1f;
    private float _currentJumpTime;
    
    public void Start()
    {
      _characterMovement._canJump;
      _currentJumpTime = _jumpTime;
    }

    public void Execute()
    {
      _currentJumpTime -= _jumpTimeStep;
    }

    public IState CalculateNextState()
    {
      if (_currentJumpTime <= 0)
        return _characterMovement._states.Falling;
      else
        return this;
    }

    public void End() { }
  }
}
```

## Installation

Make sure you have standalone [Git](https://git-scm.com/downloads) installed first.

![alt text](https://github.com/YooPita/com.retrover.retrotvfx/blob/main/DemoImages/installation.png)

And paste this: `https://github.com/YooPita/com.retrover.simplefsm.git`

Or just copy the repository to your project files.
