﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.Bot.Builder.AI.QnA;

namespace Microsoft.BotBuilderSamples
{
    /// <summary>
    /// Represents the bot's references to external services.
    ///
    /// For example, Application Insights and QnaMaker services
    /// are configured here using the <see cref="Microsoft.Bot.Configuration.BotConfiguration"/> class
    /// (based on the contents of your ".bot" file).
    /// </summary>
    public class BotServices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BotServices"/> class.
        /// </summary>
        /// <param name="client">An Application Insights <see cref="TelemetryClient"/> instance.</param>
        /// <param name="qnaServices">A dictionary of named <see cref="QnAMaker"/> instances for usage within the bot.</param>
        public BotServices(TelemetryClient client, Dictionary<string, QnAMaker> qnaServices)
        {
            TelemetryClient = client ?? throw new ArgumentNullException(nameof(client));
            QnAServices = qnaServices ?? throw new ArgumentNullException(nameof(qnaServices));
        }

        /// <summary>
        /// Gets the Application Insights Telemetry client.
        /// Use this to log new custom events/metrics/traces/etc into your
        /// Application Insights service for later analysis.
        /// </summary>
        /// <value>
        /// The Application Insights <see cref="TelemetryClient"/> instance created based on configuration in the .bot file.
        /// </value>
        public TelemetryClient TelemetryClient { get; }

        /// <summary>
        /// Gets the (potential) set of QnA Services used.
        /// Given there can be multiple QnA services used in a single bot,
        /// QnA is represented as a Dictionary.  This is also modeled in the
        /// ".bot" file since the elements are named (string).
        /// This sample only uses a single QnA instance.
        /// </summary>
        /// <value>
        /// A QnAMaker client instance created based on configuration in the .bot file.
        /// </value>
        public Dictionary<string, QnAMaker> QnAServices { get; } = new Dictionary<string, QnAMaker>();
    }
}