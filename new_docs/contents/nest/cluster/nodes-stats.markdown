---
template: layout.jade
title: Connecting
menusection: cluster
menuitem: nodes-stats
---


# Nodes stats

var r = this._client.NodeInfo(NodesInfo.All);

            var node = r.Nodes.First();

you can than traverse the node info objects i.e:

            node.Value.OS.Cpu.CacheSizeInBytes;

