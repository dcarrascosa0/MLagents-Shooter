
# **DEVELOPMENT OF A MULTI-AGENT AI BASED ON DEEP REINFORCEMENT LEARNING**

**CARRASCOSA VICTORI, DAVID**

**Curs 2021-22**

**Director: ANDERS JONSSON**

**GRAU EN ENGINYERIA EN INFORMÀTICA**

## **Acknowledgments**

This TFG is dedicated to my family, especially to my father who helped me to move forward in the most difficult moments of the degree. I also want to thank my tutor who has been advising me, and my uncle who has helped me with both in knowledge and tools that he has lent me to be able to carry out this work.

## **Resum**

Avui dia la Indústria del videojoc ja representa una de les indústries més grans del món, generant molts diners i tenint grans quantitats d&#39;usuaris que interactuen d&#39;alguna manera en aquesta. A banda, un component del qual és molt característic molts videojocs és de la IA que disposa. En aquest cas es desenvolupa una IA basada en Deep Reinforcement Learning.

L&#39;objectiu és aplicar el Deep Reinforcement Learning a un videojoc de trets creat amb Unity, el qual hi hauria 2 equips de 5 agents cadascun.

## **Resumen**

Hoy en día la Industria del Video Juego ya representa una de las mayores industrias del mundo, generando mucho dinero y teniendo grandes cantidades de usuarios que interactúan de algún modo en esta. A parte un componente del cual es muy característico muchos videojuegos es de la IA que dispone. En este caso se desarrolla una IA basada en Deep Reinforcement Learning.

El objetivo es aplicar el Deep Reinforcement Learning en un videojuego de disparos creado con Unity, el cual habría 2 equipos de 5 agentes cada uno.

## **Abstract**

Nowadays, the videogame industry already represents one of the largest industries in the world, generating a lot of money and having large numbers of users who interact in some way with it. Besides, a component that is very characteristic of many videogames is the AI ​​that it has. In this case, an AI based on Deep Reinforcement Learning.

The objective is to apply Deep Reinforcement Learning in a shooting video game created with Unity, which would have 2 teams of 5 agents each.

## **EXTENDED ABSTRACT**

The motivation to do this project is my interest in video games, this industry is already very important and moves a lot of money around the world and it is increasing year after year. In addition to developing a video game that would only be the base of the project, the development of an AI makes this project more interesting. Artificial intelligence is already a topic with enormous potential, and although there is already great progress today, there is still a long way to go to achieve everything that can be done.

The main objective of this project is to develop artificial intelligence based on deep learning, specifically deep reinforcement learning. The video game will consist of a shooting game, where the characters will be able to move in all directions, rotate and shoot. This will be developed with Unity and a package called Ml-Agents which I&#39;ll explain later. To develop the AI, you first have to train it, for that, there will be two teams, each team having 5 characters, and they will compete against each other. When the AI ​​has finally been trained, the goal is that when a human player competes against the AI ​team, they face a real challenge in order to win.

Deep reinforcement learning is a branch inside of machine learning that combines reinforcement learning and deep learning. Its unique feature among other branches is that it is not required to give as input a large amount of data to train the model. The model will be trained through simulations, in contrast, the agent will make decisions and it will be trained through trial and error.

Each episode the agent is trained, it is attributed a reward, and the agent will always look for the future highest reward possible. The agent will have the possible actions it can do and it will make a decision, the rewards have to be assigned depending on what the programmer wants, positive rewards to reinforce behavior and negative rewards to discourage behavior. As I have said before, the agent will always look for the future highest reward, so through time it will learn which decisions will give him positive rewards and it will choose them more frequently and the decisions that give him negative rewards will be less frequent.

Unity is a graphic motor used to develop video games. A graphic motor is a software that has several routines and functionalities that lets the user design, create and modify the functionality of an interactive environment.

These routines and functionalities can be listed as:

- Render 3D and 2D graphics
- Physics motor to simulate physics laws
- Animations
- Sounds
- Artificial Intelligence
- Scripting

These interactive environments, also called videogames, can be made to make it playable on several platforms, such as PC, XBOX, Play Stations, Nintendo, etc.

Unity has had enormous success because it lets the community create video games in an easy way and with results that can be considered professionally. The set of resources that are available with Unity makes it possible that programmers can achieve great results. And also for the new users that want to learn about it, there are loads of tutorials and information that make this learning journal a very easy one.

The Unity Machine Learning Agents Toolkit ( ML-Agents) is an open source project that enables the games as environments for training intelligent agents using deep reinforcement learning and imitation learning, in this specific project it&#39;s used only for reinforcement learning.

Tensor Board is a toolkit from TensorFlow that lets the user visualize and experimentwith deep learning. Related to my project, that toolkit will let us visualize how the different factors of the model are evolving, such as the reward of the agent, how much time the current episode lasts, etc.

As I have mentioned previously, before testing the behavior of this AI, it has to be trained. For doing that, the desired behavior has to be learned. This process can last hours, days, and even weeks, this depends on how the brain is evolving.

The agent has three main components:

- The behavior
- The decision requester
- The Agent Script

The decision requester is a component that what it does, is make the agent choose an action, this decision will be depending on the estimation the agent does on the future reward.

The behavior component specifies how many possible actions the agent has and how many observations will take into account the agent when deciding which action to choose.

And the Agent Script contains all the script that will make our agent behaves as we desire.

In my project, each agent has 5 observations:

- The vector of the direction the agent is facing, as this is a vector of 3 dimensions, it counts as 3 observations
- If the agent can shoot, this is only a Boolean, so it will only count as one observation
- If the agent is dead or alive, this is also a Boolean

As actions it has 4 possible actions:

- Shoot or not to shoot
- Move vertically
- Move horizontally
- Rotate to left or right

These actions are not mutually exclusive, it can do more than one action at the same time

To make these agents behave as we desire we have to give a reward to each possible outcome. The agent can have individual rewards that are assigned to the agent itself and group rewards that are assigned to the group that the agent belongs to.

Positive rewards:

- When killing an enemy it&#39;s given a reward of (1/Number of Enemies).

- Each time the agent faces an enemy a reward of 0.0001, this given reward is called &quot;reward shaping&quot;, it reinforces intermediate behavior which is not the final objective of the agent to help learn faster.
- Each time it shoots it throws a ray, if this ray impacts an enemy a positive reward of 0.001.

Negative Rewards:

- A continuous negative reward of (1/ Maximum number of steps) to make the agent finish as fast as possible.

- Each time it shoots it throws a ray, if this ray doesn&#39;t impact an enemy a negative reward of -0.001.
- When projectile collides with not an enemy there is a negative reward of -0.005.
- If the agent collides with an obstacle -0.01.
- If the agent dies, -1.

The agents prioritize the group reward rather than individual reward, if all the enemies are dead, the group receives a positive reward of 1, if all the team agents are dead, the group receives a negative reward of -1.

Self-Play is a learning process where AI competes against copies of itself. This algorithm instead of depending on individual or group rewards that only show how the AI is evolving through a fixed problem, it depends on the ELO because now the AI is competing with an enemy that is evolving each time. ELO rating system is a method for calculating the relative skill level of a player in a zero-sum game. As the AI competes against past copies of itself its growth is unlimited, in contrast to before. One benefit is that we can let the AI train for long periods without the intervention of human interaction.


## **INTRODUCTION**

### **MOTIVATION**

The motivation to do this project is my interest in video games, this industry is already very important and moves a lot of money around the world and it is increasing year after year. In addition to developing a video game that would only be the base of the project, the development of an AI makes this project more interesting. Artificial intelligence is already a topic with enormous potential, and although there is already great progress today, there is still a long way to go to achieve everything that can be done.

### **OBJECTIVES**

The main objective of this project is to develop artificial intelligence based on deep learning, specifically deep reinforcement learning. The video game will consist of a shooting game, where the characters will be able to move in all directions, rotate and shoot. This will be developed with Unity and a package called Ml-Agents which I&#39;ll explain later. To develop the AI, you first have to train it, for that, there will be two teams, each team having 5 characters, and they will compete against each other. When the AI ​​has finally been trained, the goal is that when a human player competes against the AI ​​team, they face a real challenge in order to win.

### **AI HISTORY**

The history of AI began in 1950 when Alan Turing published an article called &quot;Computing machinery and intelligence&quot;[[1](#Ref1)] in the magazine Mind. In this article, Alan questioned himself asking if the machines could think and he gave a method to prove if a machine could think. This proof was called Turing Test. If a machine passed this test, it was considered that this machine could go unnoticed in a blind discussion with a human. This test is currently used in studies.

However, many researchers and experts on this topic, consider that modern artificial intelligence started in 1956 when John McCarty, Marvin Miskey, and Claude Shannon at a conference in Dartmouth shared the term &quot;The science and ingenuity of making intelligent machines, especially intelligent calculation programs&quot;. This conference was called Dartmouth Summer Research Project on Artificial Intelligence.

In the forward years, there were few notable success stories in artificial intelligence, till 1997 were the supercomputer Deep Blue of IBM won the World chess champion, Gari Kasparov. From this point, many experts that were at an inflection point were the artificial intelligence started to be known not only in academic and research aspects.

In 2011 the supercomputer Watson of IBM won the televised contest in the USA called Jeopardy. This contest consisted of asking questions on different topics and the contestant has to answer them correctly.

Watson was a cognitive supercomputer and was able to learn through work and human interaction and it retains information. In addition, it can interact with human natural language. This supercomputer still exists and is accessible through the cloud.

Also in 2011 the company Apple integrated a virtual assistant called Siri in its new smartphone iPhone 4S. Through Siri, society started to see the first sights of machine learning and deep learning.

In 2012 is when the AI exploded. According Yoshua Bengio, one of the most prestigious researchers in artificial intelligence, in his article &quot;Deep Learning&quot;[[2](#Ref2)] published in the magazine Scientific American, he gave as the date of the beginning of the AI explosion in 2012, when there were presented the first commercial products that used the artificial intelligence to understand the human talk and interact with it. These products were the virtual assistant Google Now, from the company Google, and in 2014 the virtual assistant Cortana, from the company Microsoft.

In 2016 the artificial intelligence Alpha Go from Google competed against the South-Korean Se-Dol, who was the World champion of Go, a very complex strategy game. They competed in 5 games, Alpha Go won 4 to 1, the game where Se-Dol won was because he made an unexpected initial movement, Google said that the AI needed more training to react to these unexpected movements.

In 2017 the AI, Libratus, developed at the University of Carnegie Mellon, won against four of the best poker professionals in the world.

In 2018 AI start to enter some sectors such as the automotive one. Tesla and Audi start to make use of AI to advance in autonomous driving.

In 2020 and 2021 there are big advances in the AI in the medical sector, where making use of autonomous termic sensors and applying Big Data tools there can early detect patients zero and control contagious sources.

From 2022 to 2024 is expected to increase a lot the use of IoT technologies and the devices controlled by voice. In addition, these devices would be used in domestic areas and also in working areas such as offices. It is expected that in 2024 artificial intelligence generated more than 300 billion dollars.

## **DEEP REINFORCEMENT LEARNING**

Deep reinforcement learning is a branch inside of machine learning that combines reinforcement learning and deep learning. Its unique feature among other branches is that it is not required to give as input a large amount of data to train the model. The model will be trained through simulations, in contrast, the agent will make decisions and it will be trained through trial and error.

The agent will have a list of possible actions it can do and outcomes that will give to the agent a positive or negative reward. The goal of the agent is to achieve the highest expected reward.

The agent is trained in an environment or simulation, at the beginning as the &quot;brain&quot; doesn&#39;t have any previous data it will choose from the possible actions it can do at random. Then, it will observe what outcome there is from choosing the specific action, if there is a negative reward this decision the agent has chosen will be less frequent in the future, if the reward from the outcome is positive, in the future it will be more frequent for the agent to choose the same decision.

Following this strategy, the agent through a process of learning with conditions, as a human being would do, learns how to react in different situations and decide which strategy to follow depending on the environment it is.

To calculate the expected total reward it&#39;s used the &quot;value function&quot;[[3](#Ref3)]. This value-function is often denoted as &quot;V(s)&quot; and represents how good is a state for an agent to be in. This value function uses a policy, which the agent will use to choose its actions. The formula of the value-function is:

![image](https://user-images.githubusercontent.com/104023186/174135255-12af4a1e-b326-4360-b069-978ba9486067.png)

_Figure 2.1: Value function_

Where 𝛑 is the policy that uses, then there is the optimal value function which among all possible value-functions is the one that has a higher value for all states. Thus, the optimal policy is the one that corresponds to that optimal value function.

In relation to the value-function, there is the &quot;Q function&quot; which is a state-action pair, that returns a real value. The optimal Q-function, Q\*(s, a), is the expected total reward that obtains an agent in a state &quot;s&quot; and with an action &quot;a&quot;. This function will indicate to the agent how good is for them to choose a specific action in a specific state. The relation between the value-function and the Q-function is that the value-function is equal to the maximum of the Q-functions over all possible actions.

Then, a very important equation in reinforcement learning is the Bellman equation[[4](#Ref4)]. This equation uses dynamic programming paradigm to provide a recursive definition for the optimal Q-function.

Thus, the Q\*(s, a) is equal to the summation of immediate reward after performing action &quot;a&quot; in the state &quot;s&quot; and the discounted expected future reward after transition to the next state &quot;s&quot;.

![image](https://user-images.githubusercontent.com/104023186/174135321-e8ecd1c8-5d5a-4aa5-8960-661cd3aa1323.png)

_Figure 2.2: Value-function with Q-function_

This equation is used by value-iteration and policy-iteration to compute the optimal value-function.

Value-iteration is an algorithm to calculate the optimal state value by improving iteratively the estimate of V(s). At first, V(s) is initialized at random values, then it keeps updating the Q(s, a) and V(s) till they converge. It will converge to the optimal value.

While Policy Iteration re-defines the policy at each step and computes the V(s) with its new policy, Policy Iteration will converge at the optimal policy and it often takes fewer iterations to converge than value-iteration. This is because what the agent wants is to find the optimal policy and there are times that the optimal policy will converge before the value function.

Finally, in my project, the method to maximize the expected rewards is the Policy Gradient Theorem [[5](#Ref5)]. The theorem tells us a method to calculate the gradient of the expected reward to update the policy. Policy gradient theorem affirms that the gradient of the expected rewards is equal to the expectation of the product of the reward and the gradient of the logarithm of the policy. Then, as the gradient is applied within the time factor, it will only remain the gradient of the logarithm of the probability of an action conditioned to a specific state, as we can see in figure 2.1.

![image](https://user-images.githubusercontent.com/104023186/174135406-0042ef52-33e8-4fde-ad47-8cb967e806c4.png)

_Figure 2.3: Optimal Policy_

## **VIDEOGAME COMPONENTS**

### **UNITY**

Unity[[6](#Ref6)] is a graphic motor used to develop video games. A graphic motor is a software that has several routines and functionalities that lets the user design, create and modify the functionality of an interactive environment.

These routines and functionalities can be listed as: render 3D and 2D graphics, physics motor to simulate physics laws, animations, sounds and music, artificial Intelligence and scripting.

Unity has had enormous success because it lets the community create video games in an easy way and with results that can be considered professionally. The set of resources that are available with Unity makes it possible that programmers can achieve great results. And also for the new users that want to learn about it, there are loads of tutorials and information that make this learning journal a very easy one.

### **ML-AGENTS**

The Unity Machine Learning Agents Toolkit (ML-Agents)[[7](#Ref7)] is an open source project that enables the games, as environments for training intelligent agents using deep reinforcement learning and imitation learning, in this specific project it&#39;s only used for reinforcement learning.

The ML-Agents Toolkit contains four high-level components:

- **Learning Environment** which contains the Unity scene. Here there are contained all the gameObjects and the agents that will be trained. Here the agents will collect all the observations, act accordingly to it and learn. The Unity scene has to be adapted to the necessities that we have, we have to set it up depending on our goal to make the agents learn.

- **Python Low-Level API**  contains a low-level Python interface for interacting and manipulating a learning environment. Unity doesn&#39;t integrate any python interface as it works with C#. This interface is inside the MLAgents environment. This API communicates with Unity through the Communicator.

- **External Communicator** that lives inside the Learning environment and communicates the Python API with Unity.

- **Python Trainers** which contains all the machine learning algorithms used to train the agents.

Inside the Learning Environment, there are two Unity Components:

- **Agents:** Which is attached to a Unity GameObject that its tasks are to generate observations, execute the possible actions and receive a positive or negative reward of the outcome, each agent is linked to a behavior.

- **Behaviour:** Behavior defines the possible number of actions it can take. It has a unique identifier called &quot;Behaviour Name&quot;. It receives observations and rewards from the agent and then it returns an action. There are three types of behaviors:

  - **Learning:** Which is not defined but is about to be trained.
  - **Heuristic:** Which is defined by a set of rules hard-coded.
  - **Inferance:** Which contains a Neuronal Network file.

The Learning behavior after being trained becomes an Inference Behavior.

Several agents can have the same behaviour

![image](https://user-images.githubusercontent.com/104023186/174135505-d77e8a0a-b521-40d3-aeb3-78fe635afc94.png)

_Figure 3.2.2: Ml-Agents Workflow_

### **TENSORBOARD**

Tensor Board is a toolkit from TensorFlow[[8](#Ref8)] that lets the user visualize and experimentwith deep learning. Some functionalities are: follow and visualize the metrics, visualize the model graphs, visualize histograms of weights, etc

Related to my project, that toolkit will let us visualize how the different factors of the model are evolving, such as the reward of the agent, how much time the current episode lasts, etc. These would be used in section 6 to visualize the results and discuss them.

## **VIDEOGAME DEVELOPMENT**

Now, I will explain in full detail how the videogame has been developed and all its components. As I have mentioned previously, this videogame consists of a 3D shooter between 2 teams, each time having 5 agents.

### **AGENT**

The agent is a very simple one, created through one cube, in addition, it has a gun, and there are two types of agents. They are more or less the same, the unique difference they have, is their material, in that way, we can differentiate them when they belong to different teams. Material is a file that contains information about an object&#39;s light, and its appearance that has in the scene.

 ![image](https://user-images.githubusercontent.com/104023186/174135613-2d81ac21-862d-41d9-947e-00349b73bb2f.png)

_Figure 4.1.1: Agents_

They are formed as a big cube as their body, then a gun with its shooting point, and finally 2 RayCasters, one for its front and another one for its back.

The RayCasters are the sensors the agents will have. Its task is to shoot some rays and compile the data with the objects they collide with, in a raw way we could say the RayCasters are the eyes of the agents.

![image](https://user-images.githubusercontent.com/104023186/174135635-eb544b06-a1f1-489d-a4e3-1a21fb4b238a.png)

_Figure 4.1.2: Agents Sensors_

We can define how many rays will be per direction and the angle these rays will have. As we can see in figure 4.1.2, there are more rays in the direction the agent is facing, these are made to make more efficient the agent&#39;s movements when it&#39;s facing the problem. In this case, there are 10 rays per direction in the front with only an angle of 55 degrees, while at the back there are also 10 rays per direction but with an angle of 121 degrees.

The agent can move in all directions, rotate, and also shoot a projectile.

#### **AGENT'S COMPONENTS**

Each agent has the basic components a gameObject would have, and then it has extra ones such as:

- **Box Collider:** It defines the collider zone the agent will have.

- **RigidBody:** It&#39;s a component that let the gameObject react to Physics.

- **Behavior Parameters:** This component it&#39;s used to define some parameters the agent will have when using the MLAgent model, this section will be explained in detail later.

- **Shooting Agent:** This component is the main script the agent has, it&#39;s used such as to move, shoot, collide, etc.

- **Decision Requester:** This component is also part of the Ml-Agents package and is used to make the agent decide which decision to do.

### **PROJECTILE**

When the agent shoots, it throws one projectile. This projectile is a basic gameObject with the structure of a sphere. When it&#39;s shoted, it adapts to the same material as the agent that has been the shooter.

![image](https://user-images.githubusercontent.com/104023186/174135663-786c02ef-9606-4ff8-921d-391b82a31bd6.png)

_Figure 4.2: Projectile GameObject_

This projectile can collide with several things and it will have different effects:

- If the projectile collides with another projectile, both projectiles will continue their way and there will be no effect.

- If the projectile collides with a wall or obstacle the projectile will be destroyed

- If the projectile collides with an agent of the contrary team the agent and the projectile will be destroyed.

- If the projectile collides with an agent of the same team, the projectile will continue their way and there will be no effect.

### **SCENARIO**

The scenario where all the action happens is a simple plane where there will be generated the agents, the obstacles, and the walls.

![image](https://user-images.githubusercontent.com/104023186/174135681-d9537b63-175a-43d8-8e55-33362266220b.png)

_Figure 4.3: Scenario_

It has two important components:

- The Map Generator
- Team Manager

The Map Generator components create the obstacles that are found inside the map at random, each time a new episode begins the map generator will be called.

The Team Manager component manages all the scripts that manage the teams. First of all, it initializes the agents and assigns them to a team, and then each time an agent has died, the Team manager checks if the game has finished and if it does it restart the game. The Team Manager has other functionalities apart from that.

  ### **GAME MODES**

The final video game executable will have two game modes. One is called &quot;Teams Deathmatch&quot; which will only be a simulation of battles between two teams in which each agent will behave as inference with its trained model. One team will be using a model with LSTM and the other team without it. LSTM will be explained in section 5.4.4.

And another mode will be &quot;Player Deathmatch&quot; which will be a single agent controlled by a human against a team of trained agents.

![image](https://user-images.githubusercontent.com/104023186/174140355-6a11d5f7-2cdd-4182-b8b5-2cacf319e3a0.png)
_Figure 4.4._

## **TRAINING**

Training consists in the periods where the agents are learning, they will be executing in a simulation and try multiple episodes, each episode will be a fight between team vs team, the amount of time a training lasts is up to the user. A step, is one action that the decision component of the agent has chosen. In addition, one basic component the model has is the algorithm it follows, in my project, there are several algorithms applied.

To train the models I have used the computer of my uncle whose components are explained in Annex B.

The models that use LSTM have a final size of 4MB while the ones without LSTM have a final size of 2.7MB.

### **TRAINING CONFIGURATION**

One of the most important aspects of the process of training is to configure its configuration file. This file will contain the algorithm it uses, and its parameters, such as how many layers the neuronal network will have, how many hidden units, etc.

![image](https://user-images.githubusercontent.com/104023186/174135740-733144fa-11fc-4450-a49f-701f15a32c06.png)

_Figure 5.1: Training Configuration_

This is the configuration I have used for training the model.

First of all, it&#39;s necessary to name the model&#39;s behavior, in this case, its name is &quot;shooterml&quot;. Then decide which algorithm to use, in our case, we use the algorithm MA-POCA, which it&#39;s used to train multi-agents, in section 5.4.2 there is an explanation of the algorithm.

Then we have to define the hyperparameters of the algorithm, which definition is located in Annex A.

The value of each parameter has, it has been assigned following the ML-Agents parameters guide[[9](#Ref9)], and then through testing, assigning values that gave better results

### **AGENTS CONFIGURATION**

As we have explained in section 3.2, to train the agent we need to make them learn a behavior, three main components of the behavior we need to define at every moment of the game are:

- Observations.
- Actions.
- Reward Signal.

#### **OBSERVATIONS**

The observations are what the agents perceive from the environment, due to those observations the behavior will decide which action to take. These observations must be defined in our Behavior component

![image](https://user-images.githubusercontent.com/104023186/174135802-7ae5c779-9609-4e48-b8aa-8af1cfd04ff1.png)

_Figure 5.2.1: Behavior Parameters_

As we can see there are 5 observations defined. Which correspond to:

- The direction which the agent is facing, as it&#39;s a vector in a 3 Dimension space, it requires to occupy 3 observations.

- A Boolean which says if the agent is able to shoot.

- Another Boolean which corresponds to the state of the agent, if it&#39;s at the moment dead or alive.

As in our game, the agents can rotate, the agent, when taking decisions, must be aware of its current direction where it&#39;s pointing to.

Then there is a limitation on when the agent can shoot, there is a delay between shots and the agent has to be also aware at the moment of deciding if they can shoot or not.

And finally, the state if they are dead or alive, this is only to make the agents know their current state. It&#39;s good for them to maintain themselves alive, whereas when they observe that they are dead, they receive a large negative reward.

In addition, as we mentioned in section 4.1, they have RayCasters components, each ray the agent has is also counted as an observation, but these are special ones because they don&#39;t need to be defined at the &quot;Observations&quot; parameter that can be seen in figure 5.2.1.

As each RayCaster has 10 rays per direction and there is always one ray in the direction the agent is facing, there are two directions then, there are 21 rays per RayCaster. Then for each Agent, there are 42 rays that are also observations that the behavior will take into account.

#### **ACTIONS**

Taking another look at the picture above we can see that there is also a defined number of actions. As we can see we are using discrete actions instead of continuous actions. In our case we have 4 possible actions:

- **Shoot:** The action of shooting is defined at branch 0 and its value is 2 because it only has two possible values, to shoot or not to shoot.

- **Move Horizontally:** Located at branch 1 it&#39;s similar to what happens at the shoot branch. While now we can move left, right, or decide to not move horizontally.

- **Mover Vertically:** At branch 2, we can decide to move up, down, or not to move vertically.

- **Rotate:** Located at branch 3 we can rotate the agent left, right, or decide to not rotate.

#### **REWARD SIGNAL**

Then, to modulate the agent&#39;s behavior as we desire, we have to assign them a reward depending on the different outcomes of the scenario. The agents as they are working in teams, in addition to having an individual reward, will also have a group reward that will affect all the agents of the same team. The agents will prioritize the maximization of the group reward rather than the maximization of its individual reward. That means that if it&#39;s necessary to sacrifice itself on behalf of the group&#39;s victory, they will do it. The full list of rewards will be explained later in section 5.3.

### **REWARDS CONFIGURATIONS**

As I have said in the previous section there are group rewards and individual rewards for each agent.

#### **INDIVIDUAL REWARDS**

Positive rewards:

- When killing an enemy it&#39;s given a reward of (1/Number of Enemies).

- Each time the agent faces an enemy a reward of 0.0001, this given reward is called &quot;reward shaping&quot;, it reinforces intermediate behavior which is not the final objective of the agent to help learn faster.
- Each time it shoots it throws a ray, if this ray impacts an enemy a positive reward of 0.001.

Negative Rewards:

- A continuous negative reward of (1/ Maximum number of steps) to make the agent finish as fast as possible.

- Each time it shoots it throws a ray, if this ray doesn&#39;t impact an enemy a negative reward of -0.001.
- When projectile collides with not an enemy there is a negative reward of -0.005.

- If the agent collides with an obstacle -0.01.

- If the agent dies, -1.

#### **GROUP REWARDS**

The agents prioritize the group reward rather than individual reward, if all the enemies are dead, the group receives a positive reward of 1, if all the team agents are dead, the group receives a negative reward of -1.

## **ALGORITHMS**

### **PPO**

To train individual agents without being them in a group we use the algorithm PPO or &quot;Proximal Policy Optimization&quot; developed by John Schulman in 2017 [[10](#Ref9)].

PPO is a recent advance in the field of Reinforcement Learning, which provides an improvement on Trust Region Policy Optimization(TRPO)[[11](#Ref11)].

First of all, to understand the algorithm we have to understand what a policy is. A policy is a mapping from action to state space, it is the set of instructions the agent will follow and decide which action to take depending on the situation the agent finds. When the agent is learning, as we mentioned in section 2, Policy Gradient Theorem (PGT) returns the best possible action to take. PGT plays a vital role in this point calculating the gradient of expected rewards through the rewards and the gradient of the log of the policy, in other words, the gradient of the output with respect to the parameters of the environment like it was a neural network architecture.

PPO computes and updates at each step a new policy that minimizes the cost function, always taking into account that the deviation between the old policy and the new policy is relatively small. PPO methodology ensures that the new policy is not very different from the previous policy to maintain a low variance in training. The most common implementation of PPO is through an Actor-Critic Model[[12](#Ref12)]. Which uses two Deep Neural Networks, one taking the action that the agent does, and the other one the reward. The mathematical equation of PPO is the next one:

![image](https://user-images.githubusercontent.com/104023186/174135965-bf3a0a05-2fb4-479a-8e55-cc09686ed54c.png)

_Figure 5.4.1.1 PPO Function_

Where:

- is the policy parameter.
- denotes the empirical expectation over timesteps.
- denotes the ratio of the probabilities under the new and old policies respectively, also known as Importance Sampling Ratio.
- is the estimated advantage at time t.
- is the hyperparameter that it&#39;s used to clip.

From the algorithm above we can extract some important points:

- It&#39;s a policy gradient optimization algorithm, where at each step there is an update to try to improve the policy.

- The update is not too large to ensure that there is no big difference between the old policy and the new one. It does a clipping in the update region.

- The Advantage function is the difference between the future discounted sum of rewards, within a specific state, and the value function of that policy.

- The Importance Sampling Ratio is used for the update.

- ε is a hyperparameter defined in the training configuration file in which defines the limit of the range which the update is allowed.

Then, the PPO algorithms works in the following way:

![image](https://user-images.githubusercontent.com/104023186/174136001-4f9a8248-8932-4c96-9121-60ed1a7ac104.png)

_Figure 5.4.1.2: PPO Algorithm_

We can see that the small batches of observations, also called mini-batches are used to update the policy and then thrown away to calculate a new minibatch of observations. We can say that PPO behaves exactly as other policy gradient methods, because, as other methods do, it involves the calculation of output probabilities in the forward pass, and then calculating the gradients to improve the decisions. It also uses a sampling ratio like TRPO but PPO ensures the difference between the old policy and the new policy is small, because of the ε hyperparameter, which clips the update area.

### **MA-POCA**

As we are developing a multi-agent AI, this is inside the research topic of multi-agent reinforcement learning(MARL).

MA-POCA is the algorithm we use in our project, its release was in May 2021, so it&#39;s a quite new algorithm. It&#39;s used to train a multi-agent group. Its training configuration is the same as PPO without any additional parameters, but how it works internally is different.

One problem inside MARL[[13](#Ref13)] is that there are agents that finish earlier than the end of the episode, and they still need to assign a reward to them. We refer to propagating value from rewards earned by remaining teammates to terminated agents as the _Posthumous Credit Assignment _problem. MA-POCA gives us a new solution to that problem, because the agents that die, will equally receive a reward from the remaining teammates. This reward will be a centralized one, in our project, also known as, group reward.

MA-POCA also called _MultiAgent Posthumous Credit Assignment_, it provides the functionality to train cooperative behavior, the success of the individual agent is linked to the success of the group it belongs. MA-POCA is a novel multi-agent trainer that trains a centralized critic, a neural network that acts as a &quot;coach&quot;. The whole group cooperates to achieve the team objective and then they receive a group reward. In addition, there can also be given individual rewards.

During the episode, agents can be added or removed, but even though they are still not active, they can still receive a reward. This is because, as we have mentioned previously, MA-POCA gives a solution to the _Posthumous Credit Assignment_.

### **SELF-PLAY**

Self-Play is a technique that consists of training an AI against past copies of itself, it will constantly find new techniques and strategies to overcome its latest version of itself and it will gradually become better. In PPO and MA-POCA we had as a reference of the agents&#39; performance its group reward and individual reward scores, in those algorithms as long as the rewards scores increase we could conclude that the performance was also getting better.

But in Self-Play that is not necessarily true, because the AI is competing against past copies of itself, then, it will increase the difficulty each time, and there could happen that the individual and group rewards are decreasing but in reality, the true performance of the agents are getting better. In Self-Play to reflect the true performance of the agents, it&#39;s used the metric ELO[[14](#Ref14)].

ELO Rating System is a method for calculating the relative skill levels of players in zero-sum games such as chess. It&#39;s called ELO due to its creator Arpad Elo.

In a competition between two adversaries, if they have the same ELO, it&#39;s expected to both have the same number of wins, while if one player has a higher ELO than another it means it&#39;s expected that this one will have more wins than the other one.

In our project, we use a combination of MA-POCA with Self-Play as can be seen in figure 5.1. As we can see there is an initial ELO of 1200 when starting the game. ** ** In self-play, as there are two teams, there will be one that will be the trained one that will increase or decrease the ELO and a ghost team that is the one that uses past policies.

As we can see in our project the &quot;window&quot; parameter has a value of 10, this means that the ghost team will have a maximum of 10 policies stored. The swap between these stored policies is set by the parameter &quot;swap\_steps&quot;, and to store a new policy and, if necessary substitute it for an old stored policy, is determined by the parameter &quot;save\_steps&quot;. Also, there is a swap between teams, where a training team becomes the ghost team and vice-versa, this is set by the parameter &quot;team\_change&quot;.

The increasing or decreasing of the ELO is set by our rewards. It catches the last given reward before finishing the episode, in that case, if the two teams draw it&#39;s assigned a 0 as a reward, and then +1 to the winning team and a -1 to the loser team. In the ELO Rating System, for a player to increase its ELO means there has to be a decrease in the contraries&#39; ELO. To calculate the ELO we have to apply the following formula:

![image](https://user-images.githubusercontent.com/104023186/174136059-16473c59-b91a-4239-b411-9f5894e84b3e.png)

_Figure 5.4.3: ELO Calculation_

Where r(A) it&#39;s the current ELO of player A, E(A) it&#39;s the expected score of player A, S(A) it&#39;s the result of the match and finally r&#39;(A) it&#39;s the updated ELO.

Finally, to be able to compare ELO between two agents, the agents have to be trained with the same components, if not the ELO will be relative because the real outcome will be the advantage of the different components the agent has. One example is when comparing agents with LSTM and with no LSTM, which will be explained in section 6.2.5.

### **LONG SHORT-TERM MEMORY**

Long Short-Term Memory (LSTM), is an artificial neural network that instead of using a feedforward neural network[[15](#Ref15)], uses feedback connections. If we could say that the agents&#39; RayCasters were their eyes, we could also say that LSTM would work as a brain for them that help them memorize past observations to let them decide. LSTM is a recurrent neuronal network(RNN) and unlike the neuronal networks that can&#39;t remember past values because they only act in a forward direction, RNN in addition to pointing in a forward direction also has a pointer to a backward direction.

## **RESULTS**

In this section, it will be explained in detail the process of the project and how the changes made have affected the ELO and the time it lasted to train the model. Finally there will be some comparison between different pieces of trainings and results from guman testers against the trained agents.

### **INITIAL STEPS**

Before applying the self-play algorithm and even, the MA-POCA to train multi-agents we started with the basics to learn how the ML-Agents Toolkit work. I started using the PPO algorithm and a simple project, the white ball learn to reach the prize. The prize each time it was caught, it was placed in a random position.

![image](https://user-images.githubusercontent.com/104023186/174136108-72600732-1943-472e-8e47-9fe939dd8f8d.png)
_Figure 6.1.1: Experiment 1_

When this correctly work I moved forward and increase the difficulty. In the next stage the platform sizes were increased and obstacles were placed.

When this process was also mastered we started with the shooter path. The new challenge was to start training a single agent to shoot some enemies with a basic AI.

![image](https://user-images.githubusercontent.com/104023186/174136145-471ca323-c6c8-46b5-a1df-7fd055ec41a0.png)
_Figure 6.1.2: Experiment 2_

The enemy AI was programmed to move toward the agent, and the agent learned to shoot, rotate and move strategically.

Then the next steps were to add some obstacles and a navMesh component in the enemies that were used as a pathfinding algorithm for them.

When mastered this, I implemented for the first time the MA-POCA algorithm, as the challenge was the same as the previous test, but instead of being only a single agent it already was a team of several agents.

And finally, when mastering this challenge, we introduce the Self-Play component and start training the AI with a Team vs Team competition, as we can see in figure 4.3.

### **SELF-PLAY RESULTS**

#### **ISSUES**

Each time the AI was trained and I wanted to modify something about the code, any component of the scenario, or the parameters of the training configuration file we had to start a new training.

In total, in only the Self-Play section we have 97 different pieces of training.

![image](https://user-images.githubusercontent.com/104023186/174136223-d8214d8e-7560-4195-9c2e-0423b05d90d2.png)

_Figure 6.2.1.1: All trainings_

There are training that only lasted several minutes, others that lasted some hours, and other ones that lasted several days.

Even though there is a high ELO value it doesn&#39;t mean it&#39;s a good result.

In the case of training 46, there was an ELO value of 8042, but afterward, it appear there was an error inside the code which made this value unreliable. Another issue was that if in any case there was an interruption of the training when it was training the ELO and its parameters would restart. It happened that there was a break in the house&#39;s electricity and the training was interrupted, it happened a couple of times.

![image](https://user-images.githubusercontent.com/104023186/174136286-2a26dc82-876e-403d-93c1-3cd501838240.png)

_Figure 6.2.1.3: Interrupted Trainings_

As we can see there is a sudden decrease in the Elo score, that was when the training was interrupted. In the green training, it decreased to 1200, which is the initial value for the ELO, in the case of the red training it reached 100 million steps, and the training was done, but then I increased the maximum number of steps to 200 million and when the interruption happened it restart to the 100 million&#39;s value.

#### **ADVANCES**

A considerable advance in training is the achieve to increse the training time in 2-3 times.

![image](https://user-images.githubusercontent.com/104023186/174136351-c2f37d97-26a2-4142-a76f-c3233b2d1a04.png)

_Figure 6.2.2.1: Time Comparison in Trainings_

Comparing the training 96 with the training 46 in figure 6.2.2.1, we can see that at step 24.2 million the training 46, lasted 1 day 20 hours, and 48 minutes, while the training 96 at the same step it lasted 19 hours and 41 minutes. Training 96, trained 2.27 times faster than training 46. This increment in the training time is between 2 and 3 times faster, it depends on the hyperparameters configuration file.

This increment in the training time has been due to a change in the training method. Before the increment, the agents were trained only in the Unity Editor with only one instance executing at the time. To start the training it&#39;s used the command:

```
mlagents-learn <configurationFile> –run-id <Name of the training>
```

To increment the training time I build the application and get the executable of the Unity game and then run it with no graphics displaying and setting a number of environments. These environments are different instances of the game.

Afterward, to start training we execute the command:

```
mlagents-learn <Configuration File> <Path of the executable> –run-id <Name of the training> –no-graphics –num-envs <Number of environments>
```

In my case, I was executing 16 instances of the executable at the time with no graphics displaying which made the training time goes faster.

#### **AGENTS WITH NO LSTM**

Using MA-POCA and Self-Play I trained the agents with a limit of maximum steps of 100 million.

![image](https://user-images.githubusercontent.com/104023186/174136390-6274f092-f0eb-4c77-be53-4d692b810d4e.png)

_Figure 6.2.2: Agents whithout LSTM_

The training lasted approximately 4 days and it reached an ELO of 25000 approximately.

  #### **AGENTS WITH LSTM**

Then, with the same configuration, I decided to train the agents again, with the unique difference in the implementation of LSTM in the agents.

![image](https://user-images.githubusercontent.com/104023186/174136411-a562baae-d164-45d7-92ad-2a9be037d5cc.png)

_Figure 6.2.4: Agents with LSTM_

I decide to train the agents to 28.3 million steps and it lasted 1 day and 17 hours and it reached an ELO of 10.757.

  #### **LSTM VS NO LSTM**

If we compare the results we get from both pieces of training we have that the training with LSTM was much slower than the one with no LSTM.

![image](https://user-images.githubusercontent.com/104023186/174136433-97b7711a-5be6-41b9-bccf-857a2b207c26.png)

_Figure 6.2.5: LSTM vs no LSTM_

As we can see the training with LSTM for reaching the same step point that the training with no LSTM, lasted approximately 17 hours more. This is because of, as it also considers observations and parameters from the past, the model has to take into account more elements than before. These would make the neural network work slower. However, at the same point there was a gap of 2300 of ELO, as the one with memory had a score of 10719 and the one without memory 7706. These show us that even though it trains slower, it&#39;s more efficient. But we have to take into account that the agents from both different pieces of training are not equal because the ones that use LSTM are being trained with different modules, so the ELO will be relative when comparing both teams. This has been shown in the following results.

Then I made two teams, one team using LSTM model and another one with no LSTM model, battle. The results were favorable to the agents with memory. In total, they fight 1000 times and the results were:

| RESULTS | NUM. STEPS | TIME TRAINED | ELO | VICTORIES | LOSSES |
| --- | --- | --- | --- | --- | --- |
| NO LSTM | 100 M | 4 DAYS | 25107 | 78 | 922 |
| LSTM | 28.3 M | 1 D 17 H | 10757 | 922 | 78 |

_Table 6.2.5: Results LSTM vs No LSTM_

I could say that the model trained using LSTM is the one more complete and challenging to face in a fight among other models. One interesting fact that can be seen in the battles is the strategy the agents follow. In the scenario, there is the map generator component that generates a random map of obstacles, but the borders zone is always more or less the same, it&#39;s almost empty and the obstacles are more concentrated in the central zone. The agents have learned to move circularly around the map but only in the borders zone, and always facing the center, and when they sense an enemy, move toward it and kill it.

  #### **HUMANS VS AGENTS**

To test the agents, I ask 15 volunteers to play 10 battles against the agents and then analyze the results.

The agents they face were the ones that use LSTM, which from the previous section, we could see they were the most capable of all the versions.

The results were:

| Results | Wins | Losses |
| --- | --- | --- |
| User 1 | 1 | 9 |
| User 2 | 3 | 7 |
| User 3 | 0 | 10 |
| User 4 | 5 | 5 |
| User 5 | 8 | 2 |
| User 6 | 3 | 7 |
| User 7 | 0 | 10 |
| User 8 | 4 | 6 |
| User 9 | 2 | 8 |
| User 10 | 2 | 8 |
| User 11 | 4 | 6 |
| User 12 | 2 | 8 |
| User 13 | 5 | 5 |
| User 14 | 6 | 4 |
| User 15 | 3 | 7 |

_Table 6.2.6.1: Human vs Agents_

As we can see, in general, the results were positive for the agent&#39;s perspective. In almost all cases the agents part, had more wins than the human.

When analyzing the results with its testers, we can see that the ones that could achieve more wins than the agents were the ones that spend more time playing video games, their feedback was that they, at the firsts battles, could discover which were the pattern the agents more or less followed. While the other testers didn&#39;t discover the pattern or it was too late for them when they dit it.

| WINS | % |
| --- | --- |
| 0 – 2 | 40 |
| 3 – 4 | 33.33 |
| 5 – 6 | 20 |
| 7 – 8 | 6.66 |
| 9 - 10 | 0 |

_Table 6.2.6.2: Wins Ratio_

As we can see in table 6.2.6.2, nobody has won 9 battles or more, while only a 8.66% have won 7 battles or more. Then, several people have won between 5-6 battles, the 20%, and the 33.33% have won between 3-4 battles. Finally, the biggest tan percent have won between 0 and 2 battles, the 40% of the participants. As we can see, the higher the number of wins are, the lower the tan percent of people will be. This shows us that the results are satisfactory, if we take into account the agent&#39;s performance.

From the results and feedback of the testers, I could say I&#39;m glad about the actual state of the agent&#39;s model, but they need more training to optimize the policies they have and try to make the agents don&#39;t follow an obvious pattern.

## **CONCLUSIONS AND FUTURE WORK**

From the results we have gotten, we can conclude that the objective of this project has been achieved. However, we could also say that as it&#39;s mentioned in section 6.2.6, the agents could be trained for longer periods to get better results, or at least improve their performance. Even though the agent&#39;s performance fulfills its objective, it&#39;s easy to see that their behavior is not what a human would do, their performance it&#39;s quite illogic from a human perspective, that could be another thing to improve, one solution might be to train them during larger periods.

Another aspect that could be done to improve the performance would be optimizing the training configuration parameters and adding more sensors. As at the current state of the game the agents have a great view only of the objects that are in front of them. In the sides and back of the agent also has sensors but only very few of them. If we increase the number of sensors it has in all directions, despite making the training slower, the efficiency of the agent would increase.

Finally, I would like to say that when I started with this project I had zero experience with deep learning or with the toolkit of ML-Agents, and this project has helped me to increase my knowledge of this topic and realize the wide variance of applications the deep learning could have and its potential.

# **REFERENCES**

_[1]_Turing, A. M., &amp; Haugeland, J. (1950). Computing machinery and intelligence. _The Turing Test: Verbal Behavior as the Hallmark of Intelligence_, 29-56.

[https://books.google.es/books?hl=es&amp;lr=&amp;id=CEMYUU\_HFMAC&amp;oi=fnd&amp;pg=PA67&amp;dq=Turing,+A.+M.,+%26+Haugeland,+J.+(1950).+Computing+machinery+and+intelligence.+The+Turing+Test:+Verbal+Behavior+as+the+Hallmark+of+Intelligence,+29-56.&amp;ots=dQifNP049G&amp;sig=a32Mp\_WPQZgyRWbJf2Z5zXrrdGY](https://books.google.es/books?hl=es&amp;lr=&amp;id=CEMYUU_HFMAC&amp;oi=fnd&amp;pg=PA67&amp;dq=Turing,+A.+M.,+%26+Haugeland,+J.+(1950).+Computing+machinery+and+intelligence.+The+Turing+Test:+Verbal+Behavior+as+the+Hallmark+of+Intelligence,+29-56.&amp;ots=dQifNP049G&amp;sig=a32Mp_WPQZgyRWbJf2Z5zXrrdGY)

[2] Goodfellow, I., Bengio, Y., &amp; Courville, A. (2016). _Deep learning_. MIT press.

[https://books.google.es/books?hl=es&amp;lr=&amp;id=omivDQAAQBAJ&amp;oi=fnd&amp;pg=PR5&amp;dq=Goodfellow,+I.,+Bengio,+Y.,+%26+Courville,+A.+(2016).+Deep+learning.+MIT+press.&amp;ots=MNR3bnlIVV&amp;sig=pIv94Zl8hkL7QgUB1\_Oi3k53i\_U](https://books.google.es/books?hl=es&amp;lr=&amp;id=omivDQAAQBAJ&amp;oi=fnd&amp;pg=PR5&amp;dq=Goodfellow,+I.,+Bengio,+Y.,+%26+Courville,+A.+(2016).+Deep+learning.+MIT+press.&amp;ots=MNR3bnlIVV&amp;sig=pIv94Zl8hkL7QgUB1_Oi3k53i_U)

[3] Alzantot, M. (2018, 8 octubre). _Deep Reinforcement Learning Demysitifed (Episode 2) — Policy Iteration, Value Iteration and Q-learning_. Medium. [https://medium.com/@m.alzantot/deep-reinforcement-learning-demysitifed-episode-2-policy-iteration-value-iteration-and-q-978f9e89ddaa#:%7E:text=Value%20function,agent%20starting%20from%20state%20s%20.](https://medium.com/@m.alzantot/deep-reinforcement-learning-demysitifed-episode-2-policy-iteration-value-iteration-and-q-978f9e89ddaa#:%7E:text=Value%20function,agent%20starting%20from%20state%20s%20.)

[4] Wikipedia contributors. (2022, 29 mayo). _Bellman equation_. Wikipedia. [https://en.wikipedia.org/wiki/Bellman\_equation](https://en.wikipedia.org/wiki/Bellman_equation)

[5] Kapoor, S. (2018, 21 junio). _Policy Gradients in a Nutshell - Towards Data Science_. Medium.

[https://towardsdatascience.com/policy-gradients-in-a-nutshell-8b72f9743c5d](https://towardsdatascience.com/policy-gradients-in-a-nutshell-8b72f9743c5d)

[6]Unity-Technologies, &quot;Plataforma de Unity&quot;

[https://unity.com/es/products/unity-platform](https://unity.com/es/products/unity-platform)

[7] Unity Technologies, &quot;Unity ML-Agents Toolkit&quot;

[https://github.com/Unity-Technologies/ml-agents](https://github.com/Unity-Technologies/ml-agents)

[8] TensorFlow, &quot;TensorFlow Overview&quot;

[https://www.tensorflow.org/overview](../%20https:/www.tensorflow.org/overview)

[9] _ml-agents/Training-Configuration-File.md at main · Unity-Technologies/ml-agents_. (s. f.). GitHub.

[https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Training-Configuration-File.md](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/Training-Configuration-File.md)

[10] Schulman, J., Wolski, F., Dhariwal, P., Radford, A., &amp; Klimov, O. (2017). Proximal policy optimization algorithms. _arXiv preprint arXiv:1707.06347_.

[https://arxiv.org/abs/1707.06347](https://arxiv.org/abs/1707.06347)

[11] Schulman, J., Levine, S., Abbeel, P., Jordan, M., &amp; Moritz, P. (2015, June). Trust region policy optimization. In _International conference on machine learning_ (pp. 1889-1897). PMLR.

[https://proceedings.mlr.press/v37/schulman15.html](https://proceedings.mlr.press/v37/schulman15.html)

[12] Joel, D., Niv, Y., &amp; Ruppin, E. (2002). Actor–critic models of the basal ganglia: New anatomical and computational perspectives. _Neural networks_, _15_(4-6), 535-547.Cohen, A.,

[https://www.sciencedirect.com/science/article/pii/S0893608002000473](https://www.sciencedirect.com/science/article/pii/S0893608002000473)

[13] Cohen, A., Teng, E., Berges, V. P., Dong, R. P., Henry, H., Mattar, M., ... &amp; Ganguly, S. (2021). On the Use and Misuse of Absorbing States in Multi-agent Reinforcement Learning. _arXiv preprint arXiv:2111.05992_.

[http://aaai-rlg.mlanctot.info/papers/AAAI22-RLG\_paper\_32.pdf](http://aaai-rlg.mlanctot.info/papers/AAAI22-RLG_paper_32.pdf)

[14] Wikipedia contributors. (s. f.). _Elo rating system_. Wikipedia.

[https://en.wikipedia.org/wiki/Elo\_rating\_system](https://en.wikipedia.org/wiki/Elo_rating_system)

[15] Wikipedia contributors. (2022b, junio 11). _Long short-term memory_. Wikipedia.

[https://en.wikipedia.org/wiki/Long\_short-term\_memory](https://en.wikipedia.org/wiki/Long_short-term_memory)

# **ANNEX A**

**Training Configuration Hyperparameters definition**

The definition of each parameter are:

- **Batch Size:** Number of experiences in each iteration of gradient descent. The number should always be multiple times smaller than the Buffer Size. If we are using continuous actions the number should be bigger than if we use discrete actions. In our case, we are using discrete actions.

- **Buffer Size:** Number of experiences to collect before updating the policy model. A larger Buffer Size corresponds to a more stable training update.

- **Learning Rate:** Initial learning rate for gradient descent. It corresponds to the strength of each gradient descent update step.

- **Beta:** Strength of the entropy regularization, which makes the policy &quot;more random&quot;.

- **Epsilon:** Influences how rapidly the policy can evolve during training.

- **Lambda:** Regularization parameter used when calculating the Generalized Advantage Estimate (GAE). This represents of as how much the agent relies on its current value estimate when calculating an updated value estimate.

- **Number of Epochs:** Number of passes to make through the experience buffer when performing gradient descent optimization.

- **Learning Rate Schedule:** Determine how the learning rate decreases over time. If it&#39;s linear it will decrease over time, if it&#39;s constant the learning rate will remain constant.

Then in &quot; **network\_settings&quot;,** we can define the parameters the neuronal network will have; how many layers, and how many hidden units.

The reward signals section enables the specification for both extrinsic and intrinsic rewards. In our project, we only configure a specific configuration for the extrinsic reward, which its functionality is to ensure that the training incorporates our environment-based reward signal. Its parameters are:

- **Strength:** Factor by which to multiply the reward given by the environment.

- **Gamma:** Discount factor for future rewards coming from the environment.

The following parameters of the configuration file are parameters that control how many steps the training can have at maximum, at how many steps it does a checkpoint, etc.

Then, we have the section of Self-Play, this section will be explained in detail later, but at the moment we can explain the parameters inside this section:

- **Window:** Define how many policies the brain will be stored at the moment, a policy is like the strategy the agent will follow

- **Play against latest model ratio:** Probability an agent will play against the latest opponent policy. We define the probability at 0.5 to ensure the agent will play against a snapshot of its opponent from a past iteration.

- **Save steps:** Defines the number of steps between snapshots. Each time the training has reached the number of steps it will take a snapshot of the current policy and store it at Window.

- **Swap steps:** Number of steps between swapping the opponents policy with a different snapshot

- **Team swap:** Number of steps between changing the team is acting as the trained one and the one is acting as the ghost one.

Finally, the parameters related to LSTM are:

- **use\_recurrent:** enabling the neural network to be recurrent.

- **sequence\_length:** defines how long will be the sequence of experiences when training

- **memory\_size:** corresponds to the size of the memory the agent must keep. If it&#39;s too low the agent might not remember a lot of things, if it&#39;s too large the training will be slower

# **ANNEX B**

**PC COMPONENTS**

Trought my personal pc I connected to my uncle PC through a VPN and a Server.

- **Case:** Corsair Carbide Air 540 - PC Case, Cube ATX, Side Window, Black

- **Motherboard:** Asus Workstation Board - Intel LGA 2066 CEB motherboard with quad-GPU, DDR4 4200MHz, dual M.2 &amp; U.2, USB 3.1 Gen 2 connector, ASUS Control Center

- **Power supply:** EVGA SuperNOVA 2000 G1 + 2000W 80 Plus Gold Modular

- **Hard Drive 1:** Seagate Exos X16 3.5 &quot;16TB SATA3

- **Hard Drive 2:** Samsung 970 EVO, Solid Hard Drive, 2 TB

- **CPU:** Intel Core i9-9940X 3.3 GHz BOX

- **RAM:** Corsair Vengeance LPX High-Performance Memory Module, 128GB, 8 x 16GB, DDR4 3200MHz XMP 2.0 C16, Black

- **Graphics Card 1:** ASUS VGA TURBO-RTX3090-24G

- **Graphics Card 2:** Gigabyte Technology GeForce RTX 3090 Turbo 24GB Graphics Card and 10495 Cuda

![image](https://user-images.githubusercontent.com/104023186/174136515-51131660-dc6c-4299-b099-fd6f9cf18a8a.png)

_Figure C: PC_

# **ANNEX C**

**SOFTWARE VERSIONS**

- Operative System: Windows 10
- Python: 3.7.9
- ML-Agents: 0.27.0
- PyTorch: 1.10.1+cu113
- Unity: 2019.4.32f1
