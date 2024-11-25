using _9Dars.Models;

namespace _9Dars.Services
{
    public class EventService
    {
        private List<Event> events;

        public EventService()
        {
            events = new List<Event>();
        }

        public Event AddEvent(Event addingEvent)
        {
            addingEvent.Id = Guid.NewGuid();
            events.Add(addingEvent);
            return addingEvent;
        }

        public Event GetEventById(Guid eventId)
        {
            foreach (var event_ in events)
            {
                if (event_.Id == eventId)
                {
                    return event_;
                }
            }
            return null;
        }

        public bool DeleteEvent(Guid eventId)
        {
            var eventFromDb = GetEventById(eventId);
            if (eventFromDb is null)
            {
                return false;
            }
            events.Remove(eventFromDb);
            return true;
        }
        public bool UpdateEvent(Event updatingEvent)
        {
            var eventFromDb = GetEventById(updatingEvent.Id);
            if (eventFromDb is null)
            {
                return false;
            }
            var index = events.IndexOf(eventFromDb);
            events[index] = updatingEvent;
            return true;
        }

        public List<Event> GetAllEvents()
        {
            return events;
        }

        public List<Event> GetEventsByLocation(string location)
        {
            var eventsByLocation = new List<Event>();
            foreach (var event_ in events)
            {
                if (event_.Location == location)
                {
                    eventsByLocation.Add(event_);
                }

            }
            return eventsByLocation;
        }

        public Event GetPopularEvent()
        {
            var mostPopularEvent = new Event();
            foreach (var event_ in events)
            {
                if (mostPopularEvent.Attendees.Count < event_.Attendees.Count)
                {
                    mostPopularEvent = event_;
                }
            }
            return mostPopularEvent;
        }

        public Event GetMaxTaggedEvent()
        {
            var maxTagAmount = 0;
            var maxTaggedEvent = new Event();
            foreach (var event_ in events)
            {
                if (maxTagAmount < event_.Tags.Count)
                {
                    maxTagAmount = event_.Tags.Count;
                    maxTaggedEvent = event_;
                }
            }
            return maxTaggedEvent;
        }

        public bool AddPersonToEvent(Guid eventId, string person)
        {
            var eventFromDb = GetEventById(eventId);
            if (eventFromDb is null)
            {
                return false;
            }
            eventFromDb.Attendees.Add(person);
            return true;

        }

    }


}
