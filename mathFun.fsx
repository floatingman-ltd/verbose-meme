let RunningAverage count (current: double) (next: double) =
    (next - current) / float (count + 1) + current