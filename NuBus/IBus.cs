﻿namespace NuBus
{
    using System;
    using System.Threading.Tasks;

    public interface IBus : IDisposable
	{
		void Start();
		void Stop();

		Task<bool> PublishAsync<TEvent>(TEvent EventMessage) where TEvent : IEvent;
		bool Publish<TEvent>(TEvent EventMessage) where TEvent : IEvent;

		Task<bool> SendAsync<TCommand>(TCommand CommandMessage) where TCommand : ICommand;
		bool Send<TCommand>(TCommand CommandMessage) where TCommand : ICommand;
	}
}
