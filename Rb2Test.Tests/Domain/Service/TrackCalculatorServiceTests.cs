using System.Collections.Generic;
using Moq;
using Rb2Test.Domain.Model;
using Rb2Test.Domain.Service;
using Xunit;

namespace Rb2Test.Tests.Domain.Service
{
    public class TrackCalculatorServiceTests 
    {

        [Fact]
        public void UngroupedTalksShouldBeGroupedSucessfully()
        {
            var talks = new List<Talk>()
            {
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 60},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 45},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 30},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 45},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 45},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 5},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 60},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 45},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 30},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 30},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 45},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 60},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 60},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 45},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 30},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 30},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 60},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 30},
                new Talk() {Title = "Writing Fast Tests Against Enterprise Rails", Length = 30},
            };

            var sut = new TrackCalculatorService();

            var trackes = sut.CalculateTracks(talks);
            
            
        }
    }
}