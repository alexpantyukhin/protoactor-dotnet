﻿using Proto.Mailbox;
using Proto.Tests.Fixture;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Proto.Tests
{
    public class PropsTests
    {
        [Fact]
        public void Given_Props_When_WithDispatcher_Then_mutate_Dispatcher()
        {
            var dispatcher = new TestDispatcher();

            var props = new Props();
            var props2 = props.WithDispatcher(dispatcher);

            Assert.NotEqual(props, props2);
            Assert.Equal(dispatcher, props2.Dispatcher);

            Assert.NotEqual(props.Dispatcher, props2.Dispatcher);
            Assert.Equal(props.MailboxProducer, props2.MailboxProducer);
            Assert.Equal(props.Middleware, props2.Middleware);
            Assert.Equal(props.MiddlewareChain, props2.MiddlewareChain);
            Assert.Equal(props.Producer, props2.Producer);
            Assert.Equal(props.Spawner, props2.Spawner);
            Assert.Equal(props.SupervisorStrategy, props2.SupervisorStrategy);
        }

        [Fact]
        public void Given_Props_When_WithMailbox_Then_mutate_MailboxProducer()
        {
            Func<IMailbox> mailboxProducer = () => new TestMailbox();

            var props = new Props();
            var props2 = props.WithMailbox(mailboxProducer);

            Assert.NotEqual(props, props2);
            Assert.Equal(mailboxProducer, props2.MailboxProducer);

            Assert.Equal(props.Dispatcher, props2.Dispatcher);
            Assert.NotEqual(props.MailboxProducer, props2.MailboxProducer);
            Assert.Equal(props.Middleware, props2.Middleware);
            Assert.Equal(props.MiddlewareChain, props2.MiddlewareChain);
            Assert.Equal(props.Producer, props2.Producer);
            Assert.Equal(props.Spawner, props2.Spawner);
            Assert.Equal(props.SupervisorStrategy, props2.SupervisorStrategy);
        }

        [Fact]
        public void Given_Props_When_WithMiddleware_Then_mutate_Middleware()
        {
            Func<Receive, Receive> middleware = r => r;
            Func<Receive, Receive> middleware2 = r => r;
            Func<Receive, Receive> middleware3 = r => r;

            var props = new Props();
            var props2 = props.WithMiddleware(middleware, middleware2);
            var props3 = props2.WithMiddleware(middleware3);

            Assert.NotEqual(props, props2);
            Assert.Equal(props.Middleware.Count + 2, props2.Middleware.Count);
            Assert.Equal(props.Middleware.Count + 3, props3.Middleware.Count);

            Assert.Equal(props.Dispatcher, props2.Dispatcher);
            Assert.Equal(props.MailboxProducer, props2.MailboxProducer);
            Assert.NotEqual(props.Middleware, props2.Middleware);
            Assert.NotEqual(props.MiddlewareChain, props2.MiddlewareChain);
            Assert.Equal(props.Producer, props2.Producer);
            Assert.Equal(props.Spawner, props2.Spawner);
            Assert.Equal(props.SupervisorStrategy, props2.SupervisorStrategy);
        }

        [Fact]
        public void Given_Props_When_WithProducer_Then_mutate_Producer()
        {
            Func<IActor> producer = () => (IActor)null;

            var props = new Props();
            var props2 = props.WithProducer(producer);

            Assert.NotEqual(props, props2);
            Assert.Equal(producer, props2.Producer);

            Assert.Equal(props.Dispatcher, props2.Dispatcher);
            Assert.Equal(props.MailboxProducer, props2.MailboxProducer);
            Assert.Equal(props.Middleware, props2.Middleware);
            Assert.Equal(props.MiddlewareChain, props2.MiddlewareChain);
            Assert.NotEqual(props.Producer, props2.Producer);
            Assert.Equal(props.Spawner, props2.Spawner);
            Assert.Equal(props.SupervisorStrategy, props2.SupervisorStrategy);
        }

        [Fact]
        public void Given_Props_When_WithSpawner_Then_mutate_Spawner()
        {
            Spawner spawner = (id, p, parent) => new PID();

            var props = new Props();
            var props2 = props.WithSpawner(spawner);

            Assert.NotEqual(props, props2);
            Assert.Equal(spawner, props2.Spawner);

            Assert.Equal(props.Dispatcher, props2.Dispatcher);
            Assert.Equal(props.MailboxProducer, props2.MailboxProducer);
            Assert.Equal(props.Middleware, props2.Middleware);
            Assert.Equal(props.MiddlewareChain, props2.MiddlewareChain);
            Assert.Equal(props.Producer, props2.Producer);
            Assert.NotEqual(props.Spawner, props2.Spawner);
            Assert.Equal(props.SupervisorStrategy, props2.SupervisorStrategy);
        }

        [Fact]
        public void Given_Props_When_WithSupervisor_Then_mutate_SupervisorStrategy()
        {
            var supervision = new DoNothingSupervisorStrategy();

            var props = new Props();
            var props2 = props.WithSupervisor(supervision);

            Assert.NotEqual(props, props2);
            Assert.Equal(supervision, props2.SupervisorStrategy);

            Assert.Equal(props.Dispatcher, props2.Dispatcher);
            Assert.Equal(props.MailboxProducer, props2.MailboxProducer);
            Assert.Equal(props.Middleware, props2.Middleware);
            Assert.Equal(props.MiddlewareChain, props2.MiddlewareChain);
            Assert.Equal(props.Producer, props2.Producer);
            Assert.Equal(props.Spawner, props2.Spawner);
            Assert.NotEqual(props.SupervisorStrategy, props2.SupervisorStrategy);
        }
    }
}
