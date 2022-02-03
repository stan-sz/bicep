// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Bicep.Core.Analyzers.Linter.Rules;
using Bicep.Core.UnitTests.Assertions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Bicep.Core.UnitTests.Diagnostics.LinterRuleTests
{
    [TestClass]
    public class MaxNumberParametersRuleTests : LinterRuleTestsBase
    {
        [TestMethod]
        public void ParameterNameInFormattedMessage()
        {
            var ruleToTest = new MaxNumberParametersRule();
            ruleToTest.GetMessage(1).Should().Be("Too many parameters. Number of parameters is limited to 1.");
        }

        private void CompileAndTest(string text, params string[] unusedParams)
        {
            AssertLinterRuleDiagnostics(MaxNumberParametersRule.Code, text, onCompileErrors: OnCompileErrors.Ignore,  diags =>
            {
                if (unusedParams.Any())
                {
                    diags.Should().HaveCount(unusedParams.Count());

                    var rule = new MaxNumberParametersRule();
                    string[] expectedMessages = unusedParams.Select(p => rule.GetMessage(MaxNumberParametersRule.MaxNumber)).ToArray();
                    diags.Select(e => e.Message).Should().ContainInOrder(expectedMessages);
                }
                else
                {
                    diags.Should().BeEmpty();
                }
            });
        }

        [DataRow(@"
                    param p1 string
                    param p2 string
                    param p3 string
                    param p4 string
                    param p5 string
                    param p6 string
                    param p7 string
                    param p8 string
                    param p9 string
                    param p10 string
                    param p11 string
                    param p12 string
                    param p13 string
                    param p14 string
                    param p15 string
                    param p16 string
                    param p17 string
                    param p18 string
                    param p19 string
                    param p20 string
                    param p21 string
                    param p22 string
                    param p23 string
                    param p24 string
                    param p25 string
                    param p26 string
                    param p27 string
                    param p28 string
                    param p29 string
                    param p30 string
                    param p31 string
                    param p32 string
                    param p33 string
                    param p34 string
                    param p35 string
                    param p36 string
                    param p37 string
                    param p38 string
                    param p39 string
                    param p40 string
                    param p41 string
                    param p42 string
                    param p43 string
                    param p44 string
                    param p45 string
                    param p46 string
                    param p47 string
                    param p48 string
                    param p49 string
                    param p50 string
                    param p51 string
                    param p52 string
                    param p53 string
                    param p54 string
                    param p55 string
                    param p56 string
                    param p57 string
                    param p58 string
                    param p59 string
                    param p60 string
                    param p61 string
                    param p62 string
                    param p63 string
                    param p64 string
                    param p65 string
                    param p66 string
                    param p67 string
                    param p68 string
                    param p69 string
                    param p70 string
                    param p71 string
                    param p72 string
                    param p73 string
                    param p74 string
                    param p75 string
                    param p76 string
                    param p77 string
                    param p78 string
                    param p79 string
                    param p80 string
                    param p81 string
                    param p82 string
                    param p83 string
                    param p84 string
                    param p85 string
                    param p86 string
                    param p87 string
                    param p88 string
                    param p89 string
                    param p90 string
                    param p91 string
                    param p92 string
                    param p93 string
                    param p94 string
                    param p95 string
                    param p96 string
                    param p97 string
                    param p98 string
                    param p99 string
                    param p100 string
                    param p101 string
                    param p102 string
                    param p103 string
                    param p104 string
                    param p105 string
                    param p106 string
                    param p107 string
                    param p108 string
                    param p109 string
                    param p110 string
                    param p111 string
                    param p112 string
                    param p113 string
                    param p114 string
                    param p115 string
                    param p116 string
                    param p117 string
                    param p118 string
                    param p119 string
                    param p120 string
                    param p121 string
                    param p122 string
                    param p123 string
                    param p124 string
                    param p125 string
                    param p126 string
                    param p127 string
                    param p128 string
                    param p129 string
                    param p130 string
                    param p131 string
                    param p132 string
                    param p133 string
                    param p134 string
                    param p135 string
                    param p136 string
                    param p137 string
                    param p138 string
                    param p139 string
                    param p140 string
                    param p141 string
                    param p142 string
                    param p143 string
                    param p144 string
                    param p145 string
                    param p146 string
                    param p147 string
                    param p148 string
                    param p149 string
                    param p150 string
                    param p151 string
                    param p152 string
                    param p153 string
                    param p154 string
                    param p155 string
                    param p156 string
                    param p157 string
                    param p158 string
                    param p159 string
                    param p160 string
                    param p161 string
                    param p162 string
                    param p163 string
                    param p164 string
                    param p165 string
                    param p166 string
                    param p167 string
                    param p168 string
                    param p169 string
                    param p170 string
                    param p171 string
                    param p172 string
                    param p173 string
                    param p174 string
                    param p175 string
                    param p176 string
                    param p177 string
                    param p178 string
                    param p179 string
                    param p180 string
                    param p181 string
                    param p182 string
                    param p183 string
                    param p184 string
                    param p185 string
                    param p186 string
                    param p187 string
                    param p188 string
                    param p189 string
                    param p190 string
                    param p191 string
                    param p192 string
                    param p193 string
                    param p194 string
                    param p195 string
                    param p196 string
                    param p197 string
                    param p198 string
                    param p199 string
                    param p200 string
                    param p201 string
                    param p202 string
                    param p203 string
                    param p204 string
                    param p205 string
                    param p206 string
                    param p207 string
                    param p208 string
                    param p209 string
                    param p210 string
                    param p211 string
                    param p212 string
                    param p213 string
                    param p214 string
                    param p215 string
                    param p216 string
                    param p217 string
                    param p218 string
                    param p219 string
                    param p220 string
                    param p221 string
                    param p222 string
                    param p223 string
                    param p224 string
                    param p225 string
                    param p226 string
                    param p227 string
                    param p228 string
                    param p229 string
                    param p230 string
                    param p231 string
                    param p232 string
                    param p233 string
                    param p234 string
                    param p235 string
                    param p236 string
                    param p237 string
                    param p238 string
                    param p239 string
                    param p240 string
                    param p241 string
                    param p242 string
                    param p243 string
                    param p244 string
                    param p245 string
                    param p246 string
                    param p247 string
                    param p248 string
                    param p249 string
                    param p250 string
                    param p251 string
                    param p252 string
                    param p253 string
                    param p254 string
                    param p255 string
                    param p256 string
        ")]
        [DataRow(@"
            param p1 string
            param p2 string
            param p3 string
            param p4 string
            param p5 string
            param p6 string
            param p7 string
            param p8 string
            param p9 string
            param p10 string
            param p11 string
            param p12 string
            param p13 string
            param p14 string
            param p15 string
            param p16 string
            param p17 string
            param p18 string
            param p19 string
            param p20 string
            param p21 string
            param p22 string
            param p23 string
            param p24 string
            param p25 string
            param p26 string
            param p27 string
            param p28 string
            param p29 string
            param p30 string
            param p31 string
            param p32 string
            param p33 string
            param p34 string
            param p35 string
            param p36 string
            param p37 string
            param p38 string
            param p39 string
            param p40 string
            param p41 string
            param p42 string
            param p43 string
            param p44 string
            param p45 string
            param p46 string
            param p47 string
            param p48 string
            param p49 string
            param p50 string
            param p51 string
            param p52 string
            param p53 string
            param p54 string
            param p55 string
            param p56 string
            param p57 string
            param p58 string
            param p59 string
            param p60 string
            param p61 string
            param p62 string
            param p63 string
            param p64 string
            param p65 string
            param p66 string
            param p67 string
            param p68 string
            param p69 string
            param p70 string
            param p71 string
            param p72 string
            param p73 string
            param p74 string
            param p75 string
            param p76 string
            param p77 string
            param p78 string
            param p79 string
            param p80 string
            param p81 string
            param p82 string
            param p83 string
            param p84 string
            param p85 string
            param p86 string
            param p87 string
            param p88 string
            param p89 string
            param p90 string
            param p91 string
            param p92 string
            param p93 string
            param p94 string
            param p95 string
            param p96 string
            param p97 string
            param p98 string
            param p99 string
            param p100 string
            param p101 string
            param p102 string
            param p103 string
            param p104 string
            param p105 string
            param p106 string
            param p107 string
            param p108 string
            param p109 string
            param p110 string
            param p111 string
            param p112 string
            param p113 string
            param p114 string
            param p115 string
            param p116 string
            param p117 string
            param p118 string
            param p119 string
            param p120 string
            param p121 string
            param p122 string
            param p123 string
            param p124 string
            param p125 string
            param p126 string
            param p127 string
            param p128 string
            param p129 string
            param p130 string
            param p131 string
            param p132 string
            param p133 string
            param p134 string
            param p135 string
            param p136 string
            param p137 string
            param p138 string
            param p139 string
            param p140 string
            param p141 string
            param p142 string
            param p143 string
            param p144 string
            param p145 string
            param p146 string
            param p147 string
            param p148 string
            param p149 string
            param p150 string
            param p151 string
            param p152 string
            param p153 string
            param p154 string
            param p155 string
            param p156 string
            param p157 string
            param p158 string
            param p159 string
            param p160 string
            param p161 string
            param p162 string
            param p163 string
            param p164 string
            param p165 string
            param p166 string
            param p167 string
            param p168 string
            param p169 string
            param p170 string
            param p171 string
            param p172 string
            param p173 string
            param p174 string
            param p175 string
            param p176 string
            param p177 string
            param p178 string
            param p179 string
            param p180 string
            param p181 string
            param p182 string
            param p183 string
            param p184 string
            param p185 string
            param p186 string
            param p187 string
            param p188 string
            param p189 string
            param p190 string
            param p191 string
            param p192 string
            param p193 string
            param p194 string
            param p195 string
            param p196 string
            param p197 string
            param p198 string
            param p199 string
            param p200 string
            param p201 string
            param p202 string
            param p203 string
            param p204 string
            param p205 string
            param p206 string
            param p207 string
            param p208 string
            param p209 string
            param p210 string
            param p211 string
            param p212 string
            param p213 string
            param p214 string
            param p215 string
            param p216 string
            param p217 string
            param p218 string
            param p219 string
            param p220 string
            param p221 string
            param p222 string
            param p223 string
            param p224 string
            param p225 string
            param p226 string
            param p227 string
            param p228 string
            param p229 string
            param p230 string
            param p231 string
            param p232 string
            param p233 string
            param p234 string
            param p235 string
            param p236 string
            param p237 string
            param p238 string
            param p239 string
            param p240 string
            param p241 string
            param p242 string
            param p243 string
            param p244 string
            param p245 string
            param p246 string
            param p247 string
            param p248 string
            param p249 string
            param p250 string
            param p251 string
            param p252 string
            param p253 string
            param p254 string
            param p255 string
            param p256 string
            param p257 string
            ",
            "p1")]
        [DataTestMethod]
        public void TestRule(string text, params string[] unusedParams)
        {
            CompileAndTest(text, unusedParams);
        }
    }
}
